using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Web.FlickrSystem.Data.Interfaces.Repositories;
using Web.FlickrSystem.Models.Entities;
using Web.FlickrSystem.Models.Enum;
using Web.FlickrSystem.Models.Flickr;
using Web.FlickrSystem.Models.Google;
using Web.FlickrSystem.Models.Weather;
using Web.FlikrSystem.ApplicationServices.Interfaces;

namespace Web.FlikrSystem.ApplicationServices.Services
{
    public class ImageService : IImageService
    {
        private readonly IConfigurationService _configurationService;
        private readonly ILocationSearchCacheRepository _locationSearchCacheRepository;
        private readonly IApiActivityTraceRepository _activityTraceRepository;
        private List<string> WhiteList;
        private List<string> BlackList;

        public ImageService(IConfigurationService configurationService, ILocationSearchCacheRepository locationSearchCacheRepository, IApiActivityTraceRepository activityTraceRepository)
        {
            _configurationService = configurationService;
            _locationSearchCacheRepository = locationSearchCacheRepository;
            _activityTraceRepository = activityTraceRepository;
            BlackList = new List<string> {"bushmen ","cat", "holidays","indoor","fashion","boats", "airplane", "plane", "aircraft","people","face","faces", "man", "men", "women", "dog","cat","pensioner", "car",
                "vehicle","vintage", "train","tourist", "painting", "sculpture","younggirld","modeling" ,"oldlady", "lady","oldwoman","bad"};
            WhiteList = new List<string> { "mountains","sunrise","landscape", "view", "river","mountain", "field", "sea","sky","forest", "trees", "wild", "creek", "waterfall","savannah", "sand", "vista","view","scenic","architecture" };
        }

        public async Task<ImageSearchResponseDTO> GetImages(string text, string tags)
        {
            ImageSearchResponseDTO response = new ImageSearchResponseDTO();

            var localCacheCopy = await _locationSearchCacheRepository.Get(text);

            if(localCacheCopy!=null && (DateTime.Now -localCacheCopy.DateCreated).Minutes < 15){

                var cachedResult = JsonConvert.DeserializeObject<ImageSearchResponseDTO>(localCacheCopy.Result);

                if (cachedResult.Gallery.Any())
                {
                    return cachedResult;
                }
            }

            var results = await GoogleGetGeoLocationsFromText(text);
       
            if (!results.Results.Any()) { return null; }

            var geometry = results.Results.First().Geometry;

            var images = await Search(text, tags, geometry);

            response.Weather = await WeatherSearch(geometry);

            var processedImages = PreProcessImages(images);

            response.Gallery = (await GetGallery(processedImages)).ToList();

            response.MapMarkers = GetMapMarkers(processedImages).ToList();

            await _locationSearchCacheRepository.Create(new LocationSearchCache
            {
                SearchText = text,
                Result = JsonConvert.SerializeObject(response),
                DateCreated = DateTime.Now
            });

            return response;
       
        }

        private async Task<OpenWeatherMapResponseDTO> WeatherSearch(GoogleGeometry geometry)
        {
            HttpClient client = new HttpClient();

            string url = string.Format(_configurationService.WeatherGeoCoordinateSearchUrl,geometry.Location.Lat, geometry.Location.Lng, _configurationService.WeatherApiKey);

            var result = await client.GetAsync(url);

            if (result.IsSuccessStatusCode)
            {
                var resultString = await result.Content.ReadAsStringAsync();

                var openWeatherResult = JsonConvert.DeserializeObject<OpenWeatherMapResponseDTO>(resultString);

                return openWeatherResult;
            }
            return null;
        }

        private IEnumerable<MapMarker> GetMapMarkers(IEnumerable<SearchImageDataResult> images)
        {
            var markers = new List<MapMarker>();
            foreach(var image in images)
            {
               
                var marker = new MapMarker
                {
                    Lat = decimal.Parse(image.Latitude),
                    Lng = decimal.Parse(image.Longitute)
                };
                markers.Add(marker);
            }
            return markers.Take(50);
        }

        public async Task<GoogleGeoLocationSearchResult> GoogleGetGeoLocationsFromText(string text)
        {
            HttpClient client = new HttpClient();

            var url = string.Format(_configurationService.GoogleGeoLocationSearchUrl, text, _configurationService.GoogleApiKey);

            var then = DateTime.Now;
            var result = await client.GetAsync(url);
            var elapsedtime = (DateTime.Now - then).Milliseconds;

            await _activityTraceRepository.Create(new ApiActivityTrace
            {
                ActionId = ApiActionEnum.GoogleLocationSearch,
                ProviderId = ApiProviderEnum.Google,
                DateCreated = DateTime.Now,
                TimeElapsedMS = elapsedtime,
                StatusCode = result.StatusCode.ToString()
            });

            if (result.IsSuccessStatusCode)
            {
                var resultString = await result.Content.ReadAsStringAsync();

                var resultSet = JsonConvert.DeserializeObject<GoogleGeoLocationSearchResult>(resultString);

                return resultSet;
            }
            return null;
        }

        private IEnumerable<SearchImageDataResult> PreProcessImages(IEnumerable<SearchImageDataResult> foundImages)
        {
           var temp = new List<SearchImageDataResult>();

            //preprocessor
            foreach (var img in foundImages)
            {
                if (img.Tags == null) { continue; }
                if (img.Tags.Length == 0) continue;
                var split = img.Tags.Split(" ").ToList();
                img.WhiteListCount = WhiteList.Intersect(split).Count();
                if (img.WhiteListCount == 0) continue; //throw out if nothings on the whitelist
                if (BlackList.Intersect(split).Count() > 0) continue; //throw out if any tags are on the blacklist

                if (img.Latitude == "0" || img.Longitute == "0") continue;

                // if image is ranked badly.
                //move up of whitelist tag count is high

                temp.Add(img);
               
            }
            return temp.OrderByDescending(x => x.WhiteListCount).ToList();
        }

        public async Task<IEnumerable<GalleryView>> GetGallery(IEnumerable<SearchImageDataResult> foundImages)
        {
            return await Task.Run(() =>{

                List<GalleryView> t = new List<GalleryView>();
                if (foundImages != null && foundImages.Any())
                {
                   
                     var count = 1;
                    
                    foreach (var img in foundImages)
                    {
                        var url = string.Format(_configurationService.FlickrGetImageUrl, img.Farm, img.Server, img.Id, img.Secret, "jpg");
                        t.Add(new GalleryView { Id = count, Height = 3, Width = 4, Src = url, Thumbnail = url, ThumbnailHeight = "212", ThumbnailWidth = "320" });
                        count++;
                        if (count >= 51)
                        {
                            break;
                        }
                    }
                   
                }

                return t;
            });
          
        }

        public async Task<IEnumerable<SearchImageDataResult>> Search(string text,string tags, GoogleGeometry geoLocation)
        {
            HttpClient client = new HttpClient();

            string url = string.Format(_configurationService.FlickrBaseUrl + _configurationService.FlickrActionUrl + _configurationService.FlickrSearchParams, "80c8ff1a9188b72fe3dd4a66f341ef97", geoLocation.Location.Lat, geoLocation.Location.Lng, tags, "json");
            var timestart = DateTime.Now;
            var result = await client.GetAsync(url);
            var elapsedTime = (DateTime.Now - timestart).Milliseconds;

            await _activityTraceRepository.Create(new ApiActivityTrace
            {
                ActionId = ApiActionEnum.FlickrImageSearch,
                ProviderId = ApiProviderEnum.Flikr,
                DateCreated = DateTime.Now,
                StatusCode = result.StatusCode.ToString(),
                TimeElapsedMS = elapsedTime

            });

            if (result.IsSuccessStatusCode)
            {
               var resultString=  await result.Content.ReadAsStringAsync();

                resultString =resultString.Replace("jsonFlickrApi(", "");

                resultString = resultString.TrimEnd(')');

                var x =  JsonConvert.DeserializeObject<FlikrSearchBase>(resultString);
                if (x.Stat.ToLower() == "fail")
                {
                    throw new HttpRequestException("No Results found.");
                }

                return x.Photos.Photos;
            }
            return null;
        }
    }

   
 



   
}
