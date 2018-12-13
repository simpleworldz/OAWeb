using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
   public class Nums
    {
        int num1 = 1;
        static int num2 = 1;
        public void PrintNum()
        {
            num1++;
            num2++;
            Console.WriteLine(num1 + "\t" + num2);
        }

    }
}
