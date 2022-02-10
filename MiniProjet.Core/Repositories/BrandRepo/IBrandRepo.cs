using MiniProjet.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjet.Core.Repositories.BrandRepo
{
   public interface  IBrandRepo
    {
        List<Brand> GetBrands();

        Brand GetBrand(string brandName);

        void AddBrands(Brand brand);
    }
}
