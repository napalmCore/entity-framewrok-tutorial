using EFTuto.Models;
using EFTuto.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class AddProductModel : PageModel
{
    [BindProperty]
    public Product Product { get; set; } = new Product();

    private readonly ILogger<AddProductModel> _logger;
    private readonly IProductService _productService;

    public AddProductModel(ILogger<AddProductModel> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    public IActionResult OnGet() {
        return Page();
    }
    
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {

            return Page();
        }

        _productService.AddProduct(Product);

        TempData["Message"] = "Product added successfully!";
        return RedirectToPage("Product"); // Redirect to a product list page
    }
}
