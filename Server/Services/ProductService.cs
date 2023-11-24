using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
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
        public ProductDTO[] GetProducts()
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            if(!dbContext.Products.Any()) 
            {
                return null;
            }
            List<ProductDTO> productsList = new List<ProductDTO>();
            foreach(var product in dbContext.Products)
            {
                ProductDTO productDTO = new ProductDTO(product);
                productsList.Add(productDTO);
            }

            return productsList.ToArray();
        }

        public ProductDTO AddProduct(ProductCreateDTO productCreateDTO)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            if (dbContext.Products.Any(p => p.ProductName == productCreateDTO.ProductName))
            {
                return null;
            }
            Product newProduct = new Product();
            newProduct.ProductName = productCreateDTO.ProductName;
            newProduct.CreationDate = DateTime.Now;
            dbContext.Products.Add(newProduct);
            dbContext.SaveChanges();
            ProductDTO responseProduct = new ProductDTO(newProduct);
            return responseProduct;
        }

        public ProductDTO EditProduct(long id, ProductDTO productDTO)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            if (!dbContext.Products.Any(p => p.Id == id))
            {
                return null;
            }
            Product editableProduct = dbContext.Products.First(p => p.Id == id);
            editableProduct.ProductName = productDTO.ProductName;
            dbContext.SaveChanges();
            ProductDTO responseProduct = new ProductDTO(dbContext.Products.First(p => p.Id == id));
            return responseProduct;
        }

        public void DeleteProduct(long id)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            Product deletableProduct = dbContext.Products.First(p => p.Id == id);
            dbContext.Products.Remove(deletableProduct);
            dbContext.SaveChanges();
        }


    }
}
