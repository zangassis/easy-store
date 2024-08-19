using Catalog.API.Services;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddSingleton(s =>
{
    var cosmosClient = new CosmosClient(builder.Configuration["CosmosDb:Account"], builder.Configuration["CosmosDb:Key"]);

    return new CatalogService(cosmosClient, 
        builder.Configuration["CosmosDb:DatabaseName"], 
        builder.Configuration["CosmosDb:ContainerName"]);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();