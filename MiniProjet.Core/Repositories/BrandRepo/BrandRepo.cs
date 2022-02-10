﻿using MiniProjet.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjet.Core.Repositories.BrandRepo
{
    public class BrandRepo : IBrandRepo
    {
        private List<Brand> Brands;
        public BrandRepo(List<Brand> brands)
        {
            Brands = brands;
        }
        public List<Brand> GetBrands()
        {
            return Brands;
        }
    }
}