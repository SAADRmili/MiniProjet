using MiniProjet.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjet.Core.Repositories
{
    public class ProductRepository : IService
    {

        private BrandRepository brands;
        private List<Product> Products;
        private Random random = new Random();
        public ProductRepository()
        {
            brands = new BrandRepository();
            Products = new List<Product>();

        }

        public bool AddNewProduct(Product product)
        {
            if (product.Validate())
            {
                Products.Add(product);
                return true;
            }
            else
            {
                return false;
            }


        }

        public double AddPromo(double Promo, int IdProduct)
        {
            double PromoPrice = 0;
            foreach (var item in Products)
            {
                if (item.ProductId == IdProduct)
                {
                    PromoPrice = item.ProductPrice - (item.ProductPrice * Promo);
                }
            }
            return PromoPrice;
        }

        public Product GetProduct(int IdProduct)
        {

            foreach (var item in Products)
            {
                if (item.ProductId == IdProduct)
                {
                    return item;
                }
            }
            return null;
        }

        public List<Product> GetProducts()
        {

            for (int i = 0; i < 10; i++)
            {
                Products.Add(new Product()
                {
                    ProductName = RandomStrings.RandomString(7),
                    ProductPrice = random.NextDouble(100, 300),
                    brand = brands.GetBrands()[i],
                });
            }

            return Products;
        }




        public bool RemoveProduct(int IdProduct)
        {
            var success = false;
            foreach (var item in Products.ToList())
            {
                if (item.ProductId == IdProduct)
                {
                    Products.Remove(item);
                    success = true;
                }

            }
            return success;
        }

        public bool UpdateProduct(Product product)
        {
            bool success = false;
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].ProductId == product.ProductId)
                {
                    if (product.Validate())
                    {
                        Products[i] = product;
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                }
            }
            return success;
        }
    }
}
