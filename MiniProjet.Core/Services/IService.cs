using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjet.Core.Services
{
    public interface IService
    {
        List<Product> GetProducts();

        bool AddNewProduct(Product product);

        bool RemoveProduct(int IdProduct);

        bool UpdateProduct(Product product);

        Product GetProduct(int IdProduct);

        double AddPromo(double Promo, int IdProduct);
    }
}
