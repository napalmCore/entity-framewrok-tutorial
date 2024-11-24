using EFTuto.Models;

namespace EFTuto.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly EFTutoDbContext _appDbContext;

        public ProductRepository(EFTutoDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _appDbContext.Products;
        }

        public Product GetProductById(int id)
        {
            return _appDbContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public void AddProduct(Product product)
        {
            _appDbContext.Products.Add(product);
            _appDbContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _appDbContext.Products.Update(product);
            _appDbContext.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            _appDbContext.Products.Remove(product);
            _appDbContext.SaveChanges();
        }
    }
}