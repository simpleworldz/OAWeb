using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Nums nums = new Nums();
            nums.PrintNum();
            nums.PrintNum();
            Nums nums2 = new Nums();
            nums2.PrintNum();
            nums.PrintNum();
            Console.ReadKey();
        }
    }
}
