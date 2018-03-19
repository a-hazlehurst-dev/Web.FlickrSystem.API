using System;
using Web.FlickrSystem.Models.Enum;

namespace Web.FlickrSystem.Models.Entities
{
    public class ApiActivityTrace
    {
        public int Id { get; set; }
        public ApiProviderEnum ProviderId { get; set; }
        public ApiActionEnum ActionId { get; set; }
        public int TimeElapsedMS { get; set; }
        public string StatusCode { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
