using WebsiteCollections.MinimalApi.Models;

namespace WebsiteCollections.MinimalApi.Repositories
{
    public interface IWebsiteCollectionsRepository
    {
        Task AddWebsite(WebsiteModel website);
        Task<IEnumerable<WebsiteModel>> GetAllWebsiteCollections();
        Task<IEnumerable<WebsiteModel>> GetWebsiteCollection(string collection);
    }
}
