using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Web.FlickrSystem.Models.Weather
{
    public class OpenWeatherMapResponseDTO
    {
        [JsonProperty("coords")]
        public OpenWeatherMapCoordinates Coords { get; set; }

        [JsonProperty("weather")]
        IEnumerable<OpenWeatherMapWeather> Weather { get; set; }

        [JsonProperty("main")]
        public OpenWeatherMapMain Main { get; set; }

        [JsonProperty("sys")]
        public OpenWeatherMapSun Sun { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }

    public class OpenWeatherMapSun
    {
        [JsonProperty("sunrise")]
        public int Sunrise { get; set; }
        public string SunRiseToDisplay
        {
            get
            {
               DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local);
                dtDateTime = dtDateTime.AddSeconds(Sunrise).ToLocalTime();
                return dtDateTime.ToShortTimeString();
            }
        }
        [JsonProperty("sunset")]
        public int Sunset { get; set; }
        public string SunsetToDisplay
        {
            get
            {
                DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local);
                dtDateTime = dtDateTime.AddSeconds(Sunset).ToLocalTime();
                return dtDateTime.ToShortTimeString();
            }
        }
    }

    public class OpenWeatherMapMain
    {
        public decimal Temp { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public int TempMin { get; set; }
        public int TempMax { get; set; }
    }

    public class OpenWeatherMapWeather
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("main")]
        public string Main { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
    }

    public class OpenWeatherMapCoordinates
    {
        [JsonProperty("lon")]
        public decimal Longitude { get; set; }

        [JsonProperty("lat")]
        public decimal Latitude { get; set; }
    }

  
}
