using WebsiteCollections.MinimalApi.DTOs;
using WebsiteCollections.MinimalApi.Models;
using WebsiteCollections.MinimalApi.Services;

namespace WebsiteCollections.MinimalApi.Endpoints
{
    public static class WebsiteCollectionsEndpoints
    {
        public static IEndpointRouteBuilder MapWebsiteCollectionsEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapPost("/collections", async (WebsiteDto dto, IWebsiteCollectionsService service, ILogger<Program> logger) =>
            {
                logger.LogInformation("POST - Adding website to collection {Collection} with title {Title}", dto.Collection, dto.Title);

                if (!Uri.IsWellFormedUriString(dto.Url, UriKind.Absolute))
                {
                    return Results.BadRequest("The URL provided is not valid");
                }

                if (string.IsNullOrWhiteSpace(dto.Title))
                {
                    var uri = new Uri(dto.Url);
                    dto.Title = uri.Host.Replace("www.", "").Split('.')[0];
                }

                var website = new WebsiteModel()
                {
                    Collection = dto.Collection,
                    Url = dto.Url,
                    Title = dto.Title
                };

                await service.AddWebsiteAsync(website);

                return Results.Ok("Website has been added!");
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
                return Results.Ok(websiteCollections);
            });

            return routes;
        }
    }
}
