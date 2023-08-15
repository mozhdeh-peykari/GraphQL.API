using Core.Repositories;
using GraphQL.API.Queries;
using GraphQL.API.Resolver;
using GraphQL.API.Types;
using Infrastructure.Configurations;
using Infrastructure.Data;
using Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

// mongo
var mongo = builder.Configuration.Get<MongoDbConfiguration>();
mongo.ConnectionString = "mongodb://localhost:27017";
mongo.Database = "catalogdb";
builder.Services.AddSingleton(mongo);

// Repositories
builder.Services.AddSingleton<ICatalogContext, CatalogContext>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var c = new CatalogContext(mongo);

// GraphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<ProductType>()
    .AddType<CategoryResolver>();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL("/api/graphql");
});


app.Run();
