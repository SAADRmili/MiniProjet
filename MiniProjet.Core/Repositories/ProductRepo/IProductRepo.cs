using MiniProjet.Core.Models;
using System;
using System.Collections.Generic;

namespace MiniProjet.Core.Repositories.ProductRepo
{
    public interface IProductRepo
    {
        List<Product> GetProducts();
        void AddNewProduct(Product product);
        void RemoveProduct(Guid idProduct);
        bool UpdateProduct(Product product);
        Product GetProduct(Guid idProduct);
        void AddDiscount(double promo, Product p);
        bool ValidateProduct(Product product);
    }
}
