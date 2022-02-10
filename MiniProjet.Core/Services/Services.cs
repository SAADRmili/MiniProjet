using MiniProjet.Core.Models;
using MiniProjet.Core.Repositories.BrandRepo;
using MiniProjet.Core.Repositories.ProductRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjet.Core.Services
{
    public class Services
    {
        private IProductRepo productRepo;
        private IBrandRepo brandRepo;

        public Services(IProductRepo _productRepo,IBrandRepo _brandRepo)
        {
            productRepo = _productRepo;
            brandRepo = _brandRepo;
        }

         public void AddProduct(Product product)
        {
            Guid guid = Guid.NewGuid();
           
            productRepo.AddNewProduct(product);
            if(product.Brand != null)
            {
                 brandRepo.AddBrands(product.Brand);
                 var brand = brandRepo.GetBrand(product.Brand.BrandName);
                 brand.Products.Add(product);
            }
            else
            {
               var brand = new Brand
                {
                    BrandId = guid,
                    BrandName = product.Brand.BrandName,
                    Products = new List<Product> { product }
                };
            }
           
       
        }


        public void RemoveProduct(Product product)
        {
            productRepo.RemoveProduct(product.ProductId);
            var brand = brandRepo.GetBrand(product.Brand.BrandName);
            brand.Products.Remove(product);
        }

        public void UpdateProduct(Product product)
        {
            var brand = brandRepo.GetBrand(product.Brand.BrandName);
            brand.Products.Remove(product);

            productRepo.UpdateProduct(product);

            brand = brandRepo.GetBrand(product.Brand.BrandName);

            brand.Products.Add(product);


        }


        public List<Product> GetAllProductFromBrand(string BrandName)
        {
            var brand = brandRepo.GetBrand(BrandName);

            var products = brand.Products;

            return products;
        }
    }
}
