using Shared;
using System.Security.Principal;

namespace Server.Services.ServiceInterfaces
{
    public interface IProductService
    {
        ProductDTO[] GetProducts();
        ProductDTO AddProduct(ProductCreateDTO productCreateDTO);
        ProductDTO EditProduct(long id, ProductDTO productDTO);
        void DeleteProduct(long id);
    }
}
