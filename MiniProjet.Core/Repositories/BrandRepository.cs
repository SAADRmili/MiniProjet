using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjet.Core.Repositories
{
    public class BrandRepository
    {
        private List<string> moreBrands = new List<string>() { "DIOR", "HUGO BOSS", "Armani", "Lancôme", "TOM FORD", "Yves Saint Laurent", "CALVIN KLEIN", "Diesel", "GUCCI", "HERMÈS" };
        public List<Brand> GetBrands()
        {
            List<Brand> brands = new List<Brand>();

            for (int i = 0; i < 10; i++)
            {
                brands.Add(new Brand()
                {
                    BrandName = moreBrands[i]
                });
            }
            return brands;
        }
    }
}
