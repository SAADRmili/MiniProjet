using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MiniProjet.Core.Models
{
    public class Brand
    {
        public Guid BrandId { get; private set; } = Guid.NewGuid();

        public String  BrandName { get; set; }

        public List<Product> Products { get; set; } = new();
    }
}
