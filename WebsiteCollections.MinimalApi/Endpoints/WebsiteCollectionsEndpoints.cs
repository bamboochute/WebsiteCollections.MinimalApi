using WebsiteCollections.MinimalApi.Services;
using WebsiteCollections.MinimalApi.DTOs;
using WebsiteCollections.MinimalApi.Models;

namespace WebsiteCollections.MinimalApi.Endpoints
{
    public static class WebsiteCollectionsEndpoints
    {
        public static IEndpointRouteBuilder MapWebsiteCollectionsEndpoints(this IEndpointRouteBuilder routes)
        {

            routes.MapPost("/collections", async (WebsiteDto dto, IWebsiteCollectionsService service, ILogger<Program> logger) =>
            {
                logger.LogInformation("POST - Adding website to collection {Collection} with title {Title}", dto.Collection, dto.Title);

                var website = new WebsiteModel()
                {
                    Collection = dto.Collection,
                    Url = dto.Url
                };

                await service.AddWebsiteAsync(website);

                return Results.Ok(website);
            });

            routes.MapGet("/collections", async (IWebsiteCollectionsService service, ILogger<Program> logger) =>
            {
                logger.LogInformation("GET - Retrieving all website collections");   
                var collections = await service.GetAllWebsiteCollectionsAsync();
                return Results.Ok(collections);
            });

            routes.MapGet("/collections/{collection}", async (string collection, IWebsiteCollectionsService service, ILogger<Program> logger) =>
            {
                logger.LogInformation("GET - Retrieving website collection {Collection}", collection);
                var websiteCollections = await service.GetWebsiteCollectionAsync(collection);
                return Results.Ok("websiteCollections");
            });

            return routes;
        }
    }
}
