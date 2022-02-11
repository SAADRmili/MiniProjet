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
    }
}
