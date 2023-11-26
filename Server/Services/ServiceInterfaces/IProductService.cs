using Shared;
using System.Security.Principal;

namespace Server.Services.ServiceInterfaces
{
    public interface IProductService
    {
        List<ProductDTO> GetProducts();
        bool AddProduct(ProductCreateDTO productCreateDTO);
        bool EditProduct(long id, ProductDTO productDTO);
        bool DeleteProduct(long id);
    }
}
