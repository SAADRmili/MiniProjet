using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjet.Core.Services
{
    public class ProductService
    {
       private IService _service;
        public ProductService(IService service)
        {
            _service = service;
        }

        public List<Product> GetProducts()
        {
            return _service.GetProducts();
        }

        public bool AddProduct(Product product)
        {
            return _service.AddNewProduct(product);
        }


        public bool RemoveProduct(int id)
        {
            return _service.RemoveProduct(id);
        }

        public Product GetProduct(int id)
        {
            return _service.GetProduct(id);
        }

        public double AddPromoToProduct(int id, double promo)
        {
            return _service.AddPromo(promo, id);
        }


        public bool UpdateProduct(Product product)
        {
            return _service.UpdateProduct(product);
        }
    }
}
