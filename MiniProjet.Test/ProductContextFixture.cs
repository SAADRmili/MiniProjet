using MiniProjet.Core.Models;
using MiniProjet.Core.Repositories.BrandRepo;
using MiniProjet.Core.Repositories.ProductRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjet.Test
{
    public class ProductContextFixture : IDisposable
    {
        private List<Product> products = new List<Product>();
        private List<Brand> Brands = new List<Brand>();
        private IBrandRepo brandRepo;

        public ProductRepository Context { get; private set; }

        public ProductContextFixture()
        {
            brandRepo = new BrandRepo(Brands);
            Context = new ProductRepository(products , brandRepo);
        }


        public void Dispose()
        {
            
        }
    }
}
