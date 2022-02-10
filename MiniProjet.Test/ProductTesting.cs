using MiniProjet.Core.Models;
using MiniProjet.Core.Repositories.BrandRepo;
using MiniProjet.Core.Repositories.ProductRepo;
using System;
using System.Collections.Generic;
using Xunit;

namespace MiniProjet.Test
{
    public class ProductTesting
    {
        private ProductRepository productRepository;
        private List<Product> products = new List<Product>();
        private List<Brand> Brands = new List<Brand>();
        private IBrandRepo brandRepo;

        /// <summary>
        /// --> Test for AddNewProduct
        /// </summary>
        [Theory]
       [InlineData("Product1",200) ]
       [InlineData("Product2",300) ]
       [InlineData("Product3",400) ]
       [InlineData("Product4",500) ]
        public void  PassingTestForAddProduct(string a , double b)
        {
            //arrange 
            brandRepo = new BrandRepo(Brands);
            productRepository = new ProductRepository(products,brandRepo);

           
              var  product = new Product
            {
                
                ProductName = a,
                ProductPrice = b,
                Brand =  new Brand
                {
                    BrandName ="Gucci",

                }
              };

            //act 
            productRepository.AddNewProduct(product);
            //assert
            Assert.NotEmpty(products);
            Assert.NotEmpty(Brands);
            Assert.Contains(products, prod => prod.ProductId == product.ProductId);
        }

        [Theory]
        [InlineData("", 200)]
        [InlineData("Product2", 0)]
       
        public void PassingTestForAddProductWithNullNameAndPrice(string a, double b)
        {
            //arrange 
            brandRepo = new BrandRepo(Brands);
            productRepository = new ProductRepository(products, brandRepo);


            var product = new Product
            {

                ProductName = a,
                ProductPrice = b,
                Brand = new Brand
                {
                    BrandName = "Gucci",

                }
            };

            //act 
            productRepository.AddNewProduct(product);
            //assert
            Assert.Empty(products);
            Assert.Empty(Brands);
            Assert.DoesNotContain(products, prod => prod.ProductId == product.ProductId);
        }



        [Theory]
       
        [InlineData("Product1", 1000)]

        public void PassingTestForAddProductWithNullBrand(string a, double b)
        {
            //arrange 
            brandRepo = new BrandRepo(Brands);
            productRepository = new ProductRepository(products, brandRepo);


            var product = new Product
            {

                ProductName = a,
                ProductPrice = b,
               
            };

            //act 
            productRepository.AddNewProduct(product);
            //assert
            Assert.Empty(products);
            Assert.Empty(Brands);
            Assert.DoesNotContain(products, prod => prod.ProductId == product.ProductId);
        }


        [Theory]
        [InlineData("Product1", 200)]
        [InlineData("Product2", 300)]
        [InlineData("Product3", 400)]
        [InlineData("Product4", 500)]

        public void PassingTestForRemoveProduct(string a, double b)
        {
            //arrange 
            
            brandRepo = new BrandRepo(Brands);
            productRepository = new ProductRepository(products, brandRepo);


            var product = new Product
            {

                ProductName = a,
                ProductPrice = b,
                Brand = new Brand
                {
                    BrandName = "Gucci",

                }
            };

            //act 

            productRepository.RemoveProduct(product.ProductId);

            //assert 

            Assert.DoesNotContain(products, prod => prod.ProductId == product.ProductId);

        }








    }
}
