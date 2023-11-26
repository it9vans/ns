using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Server.Data;
using Server.Services.ServiceInterfaces;
using Shared;

namespace Server.Services
{
    public class ProductService : IProductService
    {
        IDbContextFactory<ApplicationDbContext> dbContextFactory;
        public ProductService(IDbContextFactory<ApplicationDbContext> dbContext)
        {
            dbContextFactory = dbContext;
        }
        public List<ProductDTO> GetProducts()
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            //if(!dbContext.Products.Any()) 
            //{
            //    Console.WriteLine($"Joker");
            //    return null;
            //}
            List<ProductDTO> productsList = new List<ProductDTO>();
            foreach(Product product in dbContext.Products.ToList())
            {
                ProductDTO productDTO = new ProductDTO(product);
                productsList.Add(productDTO);
                Console.WriteLine($"Sended order #{productDTO.ProductName}");
            }

            return productsList;
        }

        public bool AddProduct(ProductCreateDTO productCreateDTO)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            if (dbContext.Products.Any(p => p.ProductName == productCreateDTO.ProductName))
            {
                return false;
            }
            Product newProduct = new Product();
            newProduct.ProductName = productCreateDTO.ProductName;
            newProduct.CreationDate = DateTime.Now;
            dbContext.Products.Add(newProduct);
            dbContext.SaveChanges();
            ProductDTO responseProduct = new ProductDTO(newProduct);
            return true;
        }

        public bool EditProduct(long id, ProductDTO productDTO)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            if (!dbContext.Products.Any(p => p.Id == id))
            {
                return false;
            }
            Product editableProduct = dbContext.Products.First(p => p.Id == id);
            editableProduct.ProductName = productDTO.ProductName;
            dbContext.SaveChanges();
            ProductDTO responseProduct = new ProductDTO(dbContext.Products.First(p => p.Id == id));
            return true;
        }

        public bool DeleteProduct(long id)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            if (!dbContext.Products.Any(p => p.Id == id))
            {
                return false;
            }
            Product deletableProduct = dbContext.Products.First(p => p.Id == id);
            dbContext.Products.Remove(deletableProduct);
            dbContext.SaveChanges();
            return true;
        }


    }
}
