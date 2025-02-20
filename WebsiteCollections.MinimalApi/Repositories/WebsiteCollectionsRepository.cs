using MongoDB.Driver;
using WebsiteCollections.MinimalApi.Models;

namespace WebsiteCollections.MinimalApi.Repositories
{
    public class WebsiteCollectionsRepository : IWebsiteCollectionsRepository
    {
        private readonly IMongoCollection<WebsiteModel> _websiteCollection;
        private readonly ILogger<WebsiteCollectionsRepository> _logger;

        public WebsiteCollectionsRepository(IMongoCollection<WebsiteModel> websiteCollection, ILogger<WebsiteCollectionsRepository> logger)
        {
            _websiteCollection = websiteCollection;
            _logger = logger;
        }

        public async Task AddWebsite(WebsiteModel website)
        {
            try
            {
                await _websiteCollection.InsertOneAsync(website);
                _logger.LogInformation("Website added to collection {Collection}", website.Collection);
            }
            catch (MongoException ex)
            {
                _logger.LogError(ex, "Error while adding website to collection {Collection}", website.Collection);
                throw;
            }
        }

        public async Task<IEnumerable<WebsiteModel>> GetAllWebsiteCollections()
        {
            _logger.LogInformation("Retrieving all website collections");
            try
            {
                return await _websiteCollection.Find(website => true).ToListAsync();
            }
            catch (MongoException ex)
            {
                _logger.LogError(ex, "Error while retrieving all website collections");
                throw;
            }
        }

        public async Task<IEnumerable<WebsiteModel>> GetWebsiteCollection(string collection)
        {
            _logger.LogInformation("Retrieving website collection {Collection}", collection);
            try
            {
                return await _websiteCollection.Find(website => website.Collection == collection).ToListAsync();
            }
            catch (MongoException ex)
            {
                _logger.LogError(ex, "Error while retrieving website collection {Collection}", collection);
                throw;
            }
        }
    }
}
