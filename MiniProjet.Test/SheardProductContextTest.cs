using MiniProjet.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace MiniProjet.Test
{
   public  class SheardProductContextTest : IClassFixture<ProductContextFixture> 
    {

        ProductContextFixture fixture;
        public SheardProductContextTest(ProductContextFixture fixture)
        {
            this.fixture = fixture;
        }


        [Fact]
        public void AddProductTest()
        {
            var product = new Product
            {
                ProductName = "Product1",
                ProductPrice = 500,
                Brand = new Brand
                {
                    BrandName = "Brand1"
                }
            };
            fixture.Context.AddNewProduct(product);

            var count = fixture.Context.GetProducts().Count;

            Assert.Equal(1, count);
           
        }



        [Fact]
        public void RemoveProductTest()
        {
            for (int i = 0; i < 10; i++)
            {
                var product = new Product
                {
                    ProductName = "Product"+i,
                    ProductPrice = 500,
                    Brand = new Brand
                    {
                        BrandName = "Brand"+i
                    }
                };
                fixture.Context.AddNewProduct(product);
            }

            var products = fixture.Context.GetProducts();

            var productRemoved = products[2];

            fixture.Context.RemoveProduct(productRemoved.ProductId);


            Assert.DoesNotContain(products, p => p.ProductId == productRemoved.ProductId);
        }


        [Fact]

        public void AddDiscountTest()
        {
            var product = new Product
            {
                ProductName = "Product1",
                ProductPrice = 500,
                Brand = new Brand
                {
                    BrandName = "Brand1"
                }
            };
            fixture.Context.AddNewProduct(product);

            fixture.Context.AddDiscount(0.7, product);


            Assert.NotNull(product);
            Assert.True(product.PromoPrice != null);
            Assert.Equal(150, product.PromoPrice);
        }
    }
}
