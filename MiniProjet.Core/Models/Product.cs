using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MiniProjet.Core.Models
{
    public class Product
    {
        public Guid ProductId { get;  set; }
        public string ProductName { get; set ; }
        public double ProductPrice { get; set; }
        public double PromoPrice { get; set; }
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
