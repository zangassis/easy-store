using Catalog.API.Models;
using Microsoft.Azure.Cosmos;
namespace Catalog.API.Services;

public class CatalogService
{
    private readonly Container _container;

    public CatalogService(CosmosClient cosmosClient, string databaseName, string containerName)
    {
        _container = cosmosClient.GetContainer(databaseName, containerName);
    }

    public async Task AddProductPage(ProductPage item)
    {
        try
        {
            var partitionKey = new PartitionKey(item.Id);

            await _container.UpsertItemAsync(item, partitionKey);
        }
        catch (CosmosException ex)
        {
            Console.WriteLine($"CosmosDB Error: {ex.StatusCode} - {ex.Message}");
            Console.WriteLine($"ActivityId: {ex.ActivityId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected Error: {ex.Message}");
        }
    }

    public async Task<ProductPage> GetProductPage(string id)
    {
        try
        {
            var response = await _container.ReadItemAsync<ProductPage>(id, new PartitionKey(id));
            return response.Resource;
        }
        catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }
    }
}