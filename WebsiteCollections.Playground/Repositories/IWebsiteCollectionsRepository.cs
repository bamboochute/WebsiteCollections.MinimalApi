using WebsiteCollections.Playground.Models;

namespace WebsiteCollections.Playground.Repositories
{
    public interface IWebsiteCollectionsRepository
    {
        Task AddWebsite(WebsiteModel website);
        Task<IEnumerable<WebsiteModel>> GetAllWebsiteCollections();
        Task<IEnumerable<WebsiteModel>> GetWebsiteCollection(string collection);
    }
}
