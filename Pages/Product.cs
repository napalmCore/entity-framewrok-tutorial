using EFTuto.Models;
using EFTuto.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace entity_framewrok_tutorial.Pages;

public class ProductModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    private readonly IProductService _productService;

    public ProductModel(ILogger<IndexModel> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    public void OnGet()
    {
        var products = _productService.GetProducts();

        ViewData["Products"] = products;
    }

    public IActionResult OnPostDelete(int id)
    {
        var product = _productService.GetProductById(id);
        _productService.DeleteProduct(product);

        TempData["Message"] = "Product deleted successfully!";
        return RedirectToPage("Product");
    }
}
