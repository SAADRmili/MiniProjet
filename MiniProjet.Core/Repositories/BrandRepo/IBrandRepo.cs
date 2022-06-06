using MiniProjet.Core.Models;
using System.Collections.Generic;

namespace MiniProjet.Core.Repositories.BrandRepo
{
    public interface IBrandRepo
    {
        List<Brand> GetBrands();
        Brand GetBrand(string brandName);
        void AddBrands(Brand brand);
    }
}
