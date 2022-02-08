using MiniProjet.Core;
using MiniProjet.Core.Repositories;
using MiniProjet.Core.Services;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace MiniProjet.Test
{
    public class ProductTesting
    {
        private static ProductRepository productRepository = new ProductRepository();
        private BrandRepository brandRepository = new BrandRepository();
        private ProductService productservice = new ProductService(productRepository); 
        private List<Product> products;
        private List<Brand> brands;

        public ProductTesting()
        {
            
           

        }


        /// <summary>
        ///  Test ->  Ajout des nouveaux produits
        /// </summary>

        [Fact]
        public void PassingTestForAddNewProduct()
        {

            products = productservice.GetProducts();

            brands = brandRepository.GetBrands();
            //arrange 
            var product = new Product() { ProductName = "Gucci", ProductPrice = 500, brand = brands[9] };

            //act 
            var success = productservice.AddProduct(product);

            //asssert 


            Assert.NotNull(product);
            Assert.True(success);
            Assert.True(product.ProductId > 0);

        }

        [Fact]
        public void PassingTestForAddNewProductWithNameNull()
        {

            products = productservice.GetProducts();

            brands = brandRepository.GetBrands();
            //arrange 
            var product = new Product() { ProductName = "", ProductPrice = 500, brand = brands[9] };

            //act 
            var sucess = productservice.AddProduct(product);

            //asssert 
            Assert.False(sucess);

        }


        /// <summary>
        /// Test -> Modifications des infos du produits
        /// </summary>

        [Fact]

        public void PassingTestForUpdateProduct()
        {

            products = productservice.GetProducts();

        
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

            products = productservice.GetProducts();

            
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
        public void PassingTestForUpdateProductWithIdNotDispo()
        {

            products = productservice.GetProducts();

        
            var productId = 41;
            var nameProductChanged = "updatedProduct";


            //act 
            bool success = false;
            var product = productservice.GetProduct(productId);
            if (product == null)
            {
                success = false;
            }
            else
            {
                product.ProductName = nameProductChanged;
                success = productservice.UpdateProduct(product);
            }


            //assert

            Assert.Null(product);
            Assert.False(success);

        }




        /// <summary>
        ///  Test --> Suppression des produits 
        /// </summary>

        [Fact]
        public void PassingTestForRemoveProduct()
        {

            products = productservice.GetProducts();

        
            //arrange 
            var ex = true;

            //act

            var act = productservice.RemoveProduct(2);
            //assert 

            Assert.Equal(ex, act);
        }

        [Fact]
        public void PassingTestForRemoveProductUsingMoq()
        {

            products = productservice.GetProducts();

         
            var service = new Mock<IService>();

            service.Setup(x => x.RemoveProduct(1)).Returns(true);

            var expted = true;

            Assert.Equal(expted, service.Object.RemoveProduct(1));

        }


        [Fact]
        public void PassingTestForRemoveProductWithIdNoDispo()
        {

            products = productservice.GetProducts();

          
            //arrange 
            var ex = false;

            //act

            var act = productservice.RemoveProduct(500);
            //assert 

            Assert.Equal(ex, act);
        }



        /// <summary>
        ///  Test --> Ajout des promos sur les produits
        /// </summary>

        [Fact]
        public void PassingTestForAddPromo()
        {

            products = productservice.GetProducts();

           
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

            products = productservice.GetProducts();

           
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


            brands = brandRepository.GetBrands();
            //arrange 

            var product = new Product { ProductName = "sss", ProductPrice = 200, brand = brands[5] };

            productservice.AddProduct(product);

            var ex = 40;

            //act

            double act = productservice.AddPromoToProduct(product.ProductId, 0.8);
            //assert 

            Assert.Equal(ex, act);
        }




        /// <summary>
        /// Test - Verfication de produit en rupture
        /// </summary>
        [Fact]
        public void PassingTestForShowProduct()
        {

            products = productservice.GetProducts();

           
            var idProduct = 7;

            //act
            var act = productservice.GetProduct(idProduct);

            //assert
            Assert.NotNull(act);
            Assert.True(act.ProductId == idProduct);

        }

        [Fact]
        public void PassingTestForShowProductWithNoExist()
        {

            products = productservice.GetProducts();

          
            var idProduct = 47;

            //act
            var act = productservice.GetProduct(idProduct);

            //assert
            Assert.Null(act);

        }


    }
}
