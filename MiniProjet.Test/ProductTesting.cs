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
        [InlineData("Product1", 200)]
        [InlineData("Product2", 300)]
        [InlineData("Product3", 400)]
        [InlineData("Product4", 500)]
        public void PassingTestForAddProduct(string a, double b)
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
            Assert.DoesNotContain(Brands, b => b.BrandId == product.Brand.BrandId);
            Assert.DoesNotContain(products, prod => prod.ProductId == product.ProductId);

        }


        [Theory]
        [InlineData("Product1", 200)]

        public void PassingTestForGetProduct(string a, double b)
        {
            //arrange 
            brandRepo = new BrandRepo(Brands);
            productRepository = new ProductRepository(products, brandRepo);


            var Addproduct = new Product
            {

                ProductName = a,
                ProductPrice = b,
                Brand = new Brand
                {
                    BrandName = "Gucci",

                }

            };

            productRepository.AddNewProduct(Addproduct);

            //act 

            var product = productRepository.GetProduct(Addproduct.ProductId);

            //assert 

            Assert.NotNull(product);
            Assert.Equal(product, Addproduct);
            Assert.Contains(products, p => p.ProductId == product.ProductId);

        }

  
    


        [Fact]
        public void PassingTestForGetProducts()
        {
            List<string> moreBrands = new List<string>() { "DIOR", "HUGO BOSS", "Armani", "Lancôme", "TOM FORD", "Yves Saint Laurent", "CALVIN KLEIN", "Diesel", "GUCCI", "HERMÈS" };
            brandRepo = new BrandRepo(Brands);
            productRepository = new ProductRepository(products, brandRepo);
            


            for (int i = 0; i < 10; i++)
            {
                
                var product = new Product
                {

                    ProductName = "Product" + i,
                    ProductPrice = 500,
                    Brand = new Brand
                    {
                        BrandName = moreBrands[i],
                    }
                };

                productRepository.AddNewProduct(product);
            }


            //assert 

            Assert.NotEmpty(products);
            Assert.True(products.Count == 10);

        }


        [Fact]

        public void PassingTestForAddDiscount()
        {
            //arrange 

            List<string> moreBrands = new List<string>() { "DIOR", "HUGO BOSS", "Armani", "Lancôme", "TOM FORD",                                              "Yves Saint Laurent", "CALVIN KLEIN", "Diesel", "GUCCI", "HERMÈS" };


            brandRepo = new BrandRepo(Brands);
            productRepository = new ProductRepository(products, brandRepo);



            for (int i = 0; i < 10; i++)
            {

                var product = new Product
                {

                    ProductName = "Product" + i,
                    ProductPrice = 500,
                    Brand = new Brand
                    {
                        BrandName = moreBrands[i],
                    }
                };

                productRepository.AddNewProduct(product);
            }


            //assert 

            foreach (var item in products)
            {
                productRepository.AddDiscount(0.8,item);
            }

            var ex = 100;
            for (int i = 0; i < products.Count; i++)
            {
                Assert.True(products[i].PromoPrice != 0);
                Assert.Equal(ex, products[i].PromoPrice);
            }


        }


        [Fact]

        public void PassingTestForAddDiscountToListOfProduct()
        {
            //arrange 
             List<string> moreBrands = new List<string>() { "DIOR", "HUGO BOSS", "Armani", "Lancôme", "TOM FORD",                                              "Yves Saint Laurent", "CALVIN KLEIN", "Diesel", "GUCCI", "HERMÈS" };
            brandRepo = new BrandRepo(Brands);
            productRepository = new ProductRepository(products, brandRepo);



            var product = new Product
            {

                ProductName = "Product1",
                ProductPrice = 500,
                Brand = new Brand
                {
                    BrandName = "Gucci",

                }

            };

            productRepository.AddNewProduct(product);
            //act 

            productRepository.AddDiscount(0.8, product);

            var ex = 100;
            //assert 

            Assert.True(product.PromoPrice != 0);
            Assert.Equal(ex, product.PromoPrice);


        }



        
    }
}
