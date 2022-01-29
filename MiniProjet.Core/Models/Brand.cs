using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MiniProjet.Core
{
    public class Brand
    {
        private static int _counter;
        public int BrandId { get; private set; }

        public string BrandName { get; set; }

        List<Product> Lst = new List<Product>();

        public List<Product> GetSetProduct

        {
            get { return Lst; }

            set { Lst = value; }
        }

        public Brand()
        {
            BrandId = Interlocked.Increment(ref _counter);
        }

        public bool Validate()
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(BrandName))
            {
                isValid = false;
            }

            return isValid;
        }

        public void Print()

        {
            Console.WriteLine("Brand:- " + this.BrandName);

            Console.WriteLine("Product Owns : ");

            foreach (Product c in this.GetSetProduct)

            {
                Console.WriteLine("Product ID:- " + c.ProductId + "  -> Product Name:- " + c.ProductName + " ---> Product Price:- " + c.ProductPrice);
            }

        }

    }
}
