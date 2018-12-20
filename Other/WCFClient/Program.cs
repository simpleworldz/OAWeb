using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.CalcServiceClient csc = new ServiceReference1.CalcServiceClient();
            Console.WriteLine(csc.Add(100, 13));
            Console.WriteLine(csc.Subtract(100,13));
            Console.ReadKey();
            ServiceReference2.CalcServiceClient csc2 = new ServiceReference2.CalcServiceClient();
            Console.WriteLine(csc2.Add(100, 13));
            Console.WriteLine(csc2.Subtract(100, 13));
            Console.ReadKey();
        }
    }
}
