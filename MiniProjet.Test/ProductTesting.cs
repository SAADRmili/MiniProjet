using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using AutoFixture;
using MiniProjet.Core.Repositories;
using MiniProjet.Core.Services;
using MiniProjet.Core;

namespace MiniProjet.Test
{
    public class ProductTesting
    {
        private ProductRepository productRepository;
        private BrandRepository brandRepository = new BrandRepository();
        private ProductService productservice;
        private List<Product> products;
        private List<Brand> brands;

        public ProductTesting()
        {
            productRepository = new ProductRepository();

            productservice = new ProductService(productRepository);

            products = productservice.GetProducts();

            brands = brandRepository.GetBrands();
        }

        [Fact]
        public void PassingTestForAddNewProduct()
        {
            //arrange 
            var product = new Product() { ProductName = "Gucci", ProductPrice = 500, brand = brands[9] };

            //act 
            productservice.AddProduct(product);

            //asssert 

            Assert.True(product.ProductId > 0);

        }

        [Fact]
        public void PassingTestForAddNewProductWithNameNull()
        {
            //arrange 
            var product = new Product() { ProductName = "", ProductPrice = 500, brand = brands[9] };

            //act 
            var sucess = productservice.AddProduct(product);

            //asssert 

            Assert.False(sucess);

        }



        [Fact]

        public void PassingTestForUpdateProduct()
        {
            var productId = 1;
            var nameProductChanged = "lolo";


            //act 
            var product = productservice.GetProduct(productId);
            product.ProductName = nameProductChanged;

            var success = productservice.UpdateProduct(product);

            var newEtat = productservice.GetProduct(productId);

            Assert.True(success);
            Assert.Equal(nameProductChanged, newEtat.ProductName);



        }




        [Fact]

        public void PassingTestForUpdateProductWithNameNull()
        {
            var productId = 1;
            var nameProductChanged = "";


            //act 
            var product = productservice.GetProduct(productId);
            product.ProductName = nameProductChanged;

            var success = productservice.UpdateProduct(product);

            //assert

            Assert.False(success);

        }

        [Fact]
        public void PassingTestForRemoveProduct()
        {
            //arrange 
            var ex = true;

            //act

            var act = productservice.RemoveProduct(2);
            //assert 

            Assert.Equal(ex, act);
        }


        [Fact]
        public void PassingTestForAddPromo()
        {

            //arrange 

            var ex = 4;

            //act

            double act = productservice.AddPromoToProduct(products[1].ProductId, 0.8);
            //assert 

            Assert.Equal(ex, act);
        }



        [Fact]
        public void PassingTestForAddPromoExisitProduct()
        {

            //arrange 

            var product = productRepository.GetProduct(5);
            product.ProductPrice = 200;
            productservice.UpdateProduct(product);

            var ex = 40;
            //act

            double act = productservice.AddPromoToProduct(product.ProductId, 0.8);

            //assert 

            Assert.Equal(ex, act);
        }



        [Fact]
        public void PassingTestForAddPromoWithAddNewProduct()
        {

            //arrange 

            var product = new Product { ProductName = "sss", ProductPrice = 200, brand = new Brand() { BrandName = "Gucci" } };
            productservice.AddProduct(product);

            var ex = 40;

            //act

            double act = productservice.AddPromoToProduct(product.ProductId, 0.8);
            //assert 

            Assert.Equal(ex, act);
        }


        [Fact]
        public void PassingTestForRemoveProductUsingMoq()
        {
            var service = new Mock<IService>();

            service.Setup(x => x.RemoveProduct(1)).Returns(true);

            var expted = true;

            Assert.Equal(expted, service.Object.RemoveProduct(1));

        }

        [Fact]
        public void PassingTestForAddPromoUsingMoq()
        {
            var service = new Mock<IService>();

            service.Setup(x => x.AddPromo(0.8, 1)).Returns(4);

            var expted = 4;

            Assert.Equal(expted, service.Object.AddPromo(0.8, 1));

        }



    }
}
