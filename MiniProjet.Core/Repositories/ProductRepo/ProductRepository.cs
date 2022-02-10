using MiniProjet.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjet.Core.Repositories.ProductRepo
{
    public class ProductRepository : IProductRepo
    {
        private List<Product> Products;
        public ProductRepository(List<Product> products)
        {
            Products = products;
        }

        public void AddDiscount(double promo, Product pr)
        {
            var product = Products.Single(p => p.ProductId == pr.ProductId);

            if(product.ProductPrice == 0)
            {
                product.PromoPrice = 0;
            }
            product.PromoPrice = product.ProductPrice - (product.ProductPrice * promo);
        }

        public void AddNewProduct(Product product)
        {
            if (!ValidateProduct(product)) Products.Add(product);
        }

        public Product GetProduct(Guid IdProduct)
        {
            return Products.Single(p => p.ProductId == IdProduct);
        }

        public List<Product> GetProducts()
        {
            return Products;
        }

        public void RemoveProduct(Guid IdProduct)
        {
            foreach (var item in Products.ToList())
            {
                if(item.ProductId == IdProduct)
                {
                    Products.Remove(item);
                }
            }
        }

        public bool UpdateProduct(Product product)
        {
            var p = GetProduct(product.ProductId);
           if(!ValidateProduct(product))
            {
                p.ProductName = product.ProductName;
                p.ProductPrice = product.ProductPrice;
                p.Brand = product.Brand;
                return true;
            }
            return false;
        }

        public bool ValidateProduct(Product product)
        {
            return   string.IsNullOrEmpty(product.ProductName) || product.ProductPrice <= 0 ;
        }
    }
}
