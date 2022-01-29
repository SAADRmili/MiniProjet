using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MiniProjet.Core
{
    public class Product
    {

        public Product()
        {
            ProductId = Interlocked.Increment(ref _counter);

        }



        private static int _counter;
        public int ProductId { get; private set; }

        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public Brand brand { get; set; }


        public bool Validate()
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(ProductName))
            {
                isValid = false;
            }


            return isValid;
        }



        public override string ToString()
        {
            return " Product ID:- " + ProductId + "\n  -> Product Name:- " + ProductName + " ---> Product Price:- " + ProductPrice + " Brand: --> " + brand.BrandName;
        }
    }
}
