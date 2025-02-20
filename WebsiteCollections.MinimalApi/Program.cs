using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using WebsiteCollections.MinimalApi.Endpoints;
using WebsiteCollections.MinimalApi.Models;
using WebsiteCollections.MinimalApi.Repositories;
using WebsiteCollections.MinimalApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

// Read MongoDB settings from configuration
var connectionString = builder.Configuration.GetValue<string>("MongoDbSettings:ConnectionString");
var databaseName = builder.Configuration.GetValue<string>("MongoDbSettings:DatabaseName");
var collectionName = builder.Configuration.GetValue<string>("MongoDbSettings:CollectionName");

// Configure client, database, and collection
var mongoClient = new MongoClient(connectionString);
var database = mongoClient.GetDatabase(databaseName);
var websiteCollection = database.GetCollection<WebsiteModel>(collectionName);

// Register the MongoDB collection, repository, and service
builder.Services.AddSingleton<IMongoCollection<WebsiteModel>>(websiteCollection);
builder.Services.AddSingleton<IWebsiteCollectionsRepository, WebsiteCollectionsRepository>();
builder.Services.AddSingleton<IWebsiteCollectionsService, WebsiteCollectionsService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapWebsiteCollectionsEndpoints();

app.Run();
