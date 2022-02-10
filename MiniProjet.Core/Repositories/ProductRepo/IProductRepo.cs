using MiniProjet.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjet.Core.Repositories.ProductRepo
{
    public interface IProductRepo
    {
        List<Product> GetProducts();

        void AddNewProduct(Product product);

        void RemoveProduct(Guid IdProduct);

        bool UpdateProduct(Product product);

        Product GetProduct(Guid IdProduct );

        void AddDiscount(double promo,Product p);

        bool ValidateProduct(Product product);
    }
}
