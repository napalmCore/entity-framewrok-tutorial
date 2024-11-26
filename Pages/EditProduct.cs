using EFTuto.Models;
using EFTuto.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class EditProductModel : PageModel
{
    [BindProperty]
    public Product Product { get; set; } = new Product();

    private readonly ILogger<AddProductModel> _logger;
    private readonly IProductService _productService;

    public EditProductModel(ILogger<AddProductModel> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    public IActionResult OnGet(int id) {
        Product = _productService.GetProductById(id);

        if (Product == null)
        {
            return NotFound();
        }

        return Page();
    }
    
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {

            return Page();
        }

        _productService.UpdateProduct(Product);

        TempData["Message"] = "Product updated successfully!";
        return RedirectToPage("Product"); // Redirect to a product list page
    }
}
