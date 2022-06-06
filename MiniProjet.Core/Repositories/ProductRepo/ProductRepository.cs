using MiniProjet.Core.Models;
using MiniProjet.Core.Repositories.BrandRepo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniProjet.Core.Repositories.ProductRepo
{
    public class ProductRepository : IProductRepo
    {
        private IBrandRepo brandRepo;
        private List<Product> Products;
        public ProductRepository(List<Product> products, IBrandRepo _brandRepo)
        {
            brandRepo = _brandRepo;
            Products = products;
        }
        public void AddDiscount(double promo, Product pr)
        {
            var product = Products.Single(p => p.ProductId == pr.ProductId);
            product.PromoPrice = product.ProductPrice - (product.ProductPrice * promo);
        }

        public void AddNewProduct(Product product)
        {
            if (!ValidateProduct(product))
            {
                Products.Add(product);
                var brand = brandRepo.GetBrand(product.Brand.BrandName);
                brand.Products.Add(product);
            }
        }

        public Product GetProduct(Guid IdProduct) => Products.Single(p => p.ProductId == IdProduct);
        public List<Product> GetProducts() => Products;

        public void RemoveProduct(Guid productId)
        {
            brandRepo.GetBrands()
                .SelectMany(brand => brand.Products)
                .ToList()
                .RemoveAll(p => p.ProductId == productId);
        }
        public bool UpdateProduct(Product product)
        {
            var p = GetProduct(product.ProductId);
            if (!ValidateProduct(product))
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
            return string.IsNullOrEmpty(product.ProductName) || product.ProductPrice <= 0 || product.Brand == null;
        }
    }
}
