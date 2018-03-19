using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Web.FlickrSystem.Models.Google.Place;
using Web.FlikrSystem.ApplicationServices.Interfaces;

namespace Web.FlikrSystem.ApplicationServices.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IConfigurationService _configurationService;

        public PlaceService (IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        public async Task<IEnumerable<string>> GetPlaces(string text)
        {
            var client = new HttpClient();

            var url = string.Format(_configurationService.GooglePlacesAutoCompleteUrl, text, _configurationService.GoogleApiKey);

            var googlePlacesResult = await client.GetAsync(url);

            if (googlePlacesResult.IsSuccessStatusCode)
            {
                var jsonResult = await googlePlacesResult.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<GooglePlacesAutoCompleteResponse>(jsonResult);

                var list = result.Predictions.Select(x => x.Label);

                return list;
                
            }

            return null;
        }
    }
}
