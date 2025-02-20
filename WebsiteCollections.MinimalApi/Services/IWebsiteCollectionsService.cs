using WebsiteCollections.MinimalApi.Models;

namespace WebsiteCollections.MinimalApi.Services
{
    public interface IWebsiteCollectionsService
    {
        Task AddWebsiteAsync(WebsiteModel website);
        Task<IEnumerable<WebsiteModel>> GetWebsiteCollectionAsync(string collection);
        Task<IEnumerable<WebsiteModel>> GetAllWebsiteCollectionsAsync();
    }
}