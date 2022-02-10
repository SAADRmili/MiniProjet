using MiniProjet.Core.Models;
using MiniProjet.Core.Repositories.BrandRepo;
using MiniProjet.Core.Repositories.ProductRepo;
using MiniProjet.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MiniProjet.Test
{
    public class ServiceTest
    {
        private Services service;
        private List<Brand> Brands = new List<Brand>();
        private List<Product> Products = new List<Product>();
        private IProductRepo productRepo;
        private IBrandRepo brandRepo;

        [Fact]

        public void  PassingTestforAddNewProductService()
        {
            //arrange
            productRepo = new ProductRepository(Products);
            brandRepo = new BrandRepo(Brands);
            service = new Services(productRepo, brandRepo);
            Guid guidPr = Guid.NewGuid();
            Guid guidBd = Guid.NewGuid();
            //act 
            var product = new Product
            {
                ProductId = guidPr,
                ProductName = "Product1",
                ProductPrice = 400,
                Brand = new Brand
                {
                    BrandId = guidBd,
                    BrandName = "Gucci",
                }
            };

            //act 
            service.AddProduct(product);

            // assert 
            Assert.NotEmpty(Products);
            Assert.NotEmpty(Brands);
            Assert.Contains(Brands, b => b.BrandId == product.Brand.BrandId);
        }
    }
}
