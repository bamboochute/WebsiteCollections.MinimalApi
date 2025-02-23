using WebsiteCollections.Playground.Models;

namespace WebsiteCollections.Playground.Services
{
    public interface IWebsiteCollectionsService
    {
        Task AddWebsiteAsync(WebsiteModel website);
        Task<IEnumerable<WebsiteModel>> GetWebsiteCollectionAsync(string collection);
        Task<IEnumerable<WebsiteModel>> GetAllWebsiteCollectionsAsync();
    }
}