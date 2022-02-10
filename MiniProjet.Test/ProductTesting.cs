using MiniProjet.Core.Models;
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
            
            productRepository = new ProductRepository(products);

            Guid guid = Guid.NewGuid();
          var  product = new Product
            {
                ProductId = guid,
                ProductName = a,
                ProductPrice = b,
            };

            //act 
            productRepository.AddNewProduct(product);
            //assert
            Assert.NotEmpty(products);
            Assert.Contains(products, prod => prod.ProductId == product.ProductId);
        }

        [Fact]
        public void PassingTestForAddProductWithNameNull()
        {
            //arrange 
            
            productRepository = new ProductRepository(products);

            Guid guid = Guid.NewGuid();
            var product = new Product
            {
                ProductId = guid,
                ProductName = "",
                ProductPrice = 300,
            };

            //act 
            productRepository.AddNewProduct(product);
            //assert
            Assert.Empty(products);
        }


        [Fact]
        public void PassingTestForAddProductWithNegativePrice()
        {
            //arrange 
            
            productRepository = new ProductRepository(products);

            Guid guid = Guid.NewGuid();
            var product = new Product
            {
                ProductId = guid,
                ProductName = "",
                ProductPrice = -80,
            };

            //act 
            productRepository.AddNewProduct(product);
            //assert
            Assert.Empty(products);
        }



        [Theory]
        [InlineData("Product1", 200)]
        [InlineData("Product2", 300)]
        [InlineData("Product3", 400)]
        [InlineData("Product4", 500)]

        public void PassingTestForRemoveProduct(string a, double b)
        {
            //arrange 
            
            productRepository = new ProductRepository(products);

            Guid guid = Guid.NewGuid();
            var product = new Product
            {
                ProductId = guid,
                ProductName = a,
                ProductPrice = b,
            };

            productRepository.AddNewProduct(product);
            //act 

            productRepository.RemoveProduct(product.ProductId);

            //assert 

            Assert.DoesNotContain(products, prod => prod.ProductId == product.ProductId);

        }

        [Theory]
        [InlineData("Product1", 200)]
        [InlineData("Product2", 300)]
        [InlineData("Product3", 400)]
        [InlineData("Product4", 500)]

        public void PassingTestForGetProduct(string a, double b)
        {
            //arrange 
         
            productRepository = new ProductRepository(products);

            Guid guid = Guid.NewGuid();
            var Addproduct = new Product
            {
                ProductId = guid,
                ProductName = a,
                ProductPrice = b,
            };

            productRepository.AddNewProduct(Addproduct);

            //act 

            var product  = productRepository.GetProduct(Addproduct.ProductId);

            //assert 

            Assert.NotNull(product);
            Assert.Equal(product, Addproduct);
            Assert.Contains(products, p => p.ProductId == product.ProductId);

        }



        [Fact]
        public void PassingTestForGetProducts()
        {
           
            productRepository = new ProductRepository(products);


            for (int i = 0; i < 10; i++)
            {
                Guid guid = Guid.NewGuid();
                var product = new Product
                {
                    ProductId = guid,
                    ProductName = "Product"+i,
                    ProductPrice = 500,
                };

                productRepository.AddNewProduct(product);
            }


            //assert 

            Assert.NotEmpty(products);
            Assert.True(products.Count == 10);

        }


        [Fact]

        public void PassingTestForUpdateProduct()
        {
            //arrange
            productRepository = new ProductRepository(products);


            for (int i = 0; i < 10; i++)
            {
                Guid guid = Guid.NewGuid();
                var product = new Product
                {
                    ProductId = guid,
                    ProductName = "Product" + i,
                    ProductPrice = 500,
                };

                productRepository.AddNewProduct(product);
            }



            //act 

            var productUpdated = products[5];
            productUpdated.ProductName = "LOLO";
            productUpdated.ProductPrice = 399;


            var success = productRepository.UpdateProduct(productUpdated);
            //assert 
            Assert.True(success);
            Assert.NotNull(productUpdated);
            Assert.True(products[5].ProductPrice == 399);
            Assert.Contains(products, p => p.ProductId == productUpdated.ProductId);

        }


        [Fact]

        public void PassingTestForUpdateProductWithNullName()
        {
            //arrange
            productRepository = new ProductRepository(products);


            for (int i = 0; i < 10; i++)
            {
                Guid guid = Guid.NewGuid();
                var product = new Product
                {
                    ProductId = guid,
                    ProductName = "Product" + i,
                    ProductPrice = 500,
                };

                productRepository.AddNewProduct(product);
            }



            //act 

            var productUpdated = productRepository.GetProduct(products[5].ProductId);

            productUpdated.ProductName = "";
            var success = productRepository.UpdateProduct(productUpdated);
            //assert 

            Assert.False(success);

        }


        [Fact]
        
        public void PassingTestForAddDiscount ()
        {
            //arrange 

            productRepository = new ProductRepository(products);

            Guid guid = Guid.NewGuid();
            var product = new Product
            {
                ProductId = guid,
                ProductName = "Product1",
                ProductPrice = 300,
            };

            productRepository.AddNewProduct(product);
            //act 

            productRepository.AddDiscount(0.8, product);

            var ex = 60;
            //assert 

            Assert.True(product.PromoPrice!=0);
            Assert.Equal(ex,product.PromoPrice);
            

        }


       
    }
}
