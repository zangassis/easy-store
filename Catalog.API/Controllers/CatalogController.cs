using Microsoft.AspNetCore.Mvc;
using Catalog.API.Models;
using Catalog.API.Services;
using CsvHelper;
using System.Globalization;

namespace Catalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CatalogController : ControllerBase
{
    private readonly CatalogService _catalogService;

    public CatalogController(CatalogService catalogService)
    {
        _catalogService = catalogService;
    }

    [HttpPost("/product-page/upload")]
    public async Task<IActionResult> UploadProductPages([FromForm] IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("File is empty.");

        using var streamReader = new StreamReader(file.OpenReadStream());
        using var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
        var productPages = csvReader.GetRecords<ProductPage>();

        foreach (var productPage in productPages)
        {
            await _catalogService.AddProductPage(productPage);
        }

        return Ok("Product pages have been uploaded and saved to the database.");
    }

    [HttpGet("/product-page")]
    public async Task<ActionResult<IEnumerable<ProductPage>>> GetProductPage([FromQuery] string id)
    {
        var productPage = await _catalogService.GetProductPage(id);
        return productPage != null ? Ok(productPage) : NotFound();
    }
}
