﻿
using Web.FlikrSystem.ApplicationServices.Interfaces;

namespace Web.FlikrSystem.ApplicationServices.Services
{
    public class ConfigurationService : IConfigurationService
    {
        #region Flickr
        public string FlickrBaseUrl => "https://api.flickr.com/services/rest/?method=";
        public string FlickrApiKey => "80c8ff1a9188b72fe3dd4a66f341ef97";
        public string FlickrActionUrl => "flickr.photos.search";
        public string FlickrSearchParams => "&api_key={0}&lat={1}&lon={2}&radius=3&extras=tags%2Cgeo&per_page=500&tags={3}&format={4}";
        public string FlickrGetImageUrl =>"https://farm{0}.staticflickr.com/{1}/{2}_{3}.{4}";
        #endregion


        public string GoogleGeoLocationSearchUrl => "https://maps.googleapis.com/maps/api/geocode/json?address={0}&key={1}";
        public string GoogleApiKey => "AIzaSyCv1TJmGi-CLd18lqfY30-qM-B37KnJ7v0";

       
    }
}
