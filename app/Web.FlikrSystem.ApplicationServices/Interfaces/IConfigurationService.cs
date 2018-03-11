
namespace Web.FlikrSystem.ApplicationServices.Interfaces
{
    public interface IConfigurationService
    {
      
        string GoogleApiKey { get; }
        string GoogleGeoLocationSearchUrl { get; }

        string FlickrApiKey { get; }
        string FlickrBaseUrl { get; }
        string FlickrActionUrl { get; }
        string FlickrSearchParams { get; }
        string FlickrGetImageUrl { get; }
    }
}
