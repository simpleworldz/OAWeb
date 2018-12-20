using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace UnityTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //默认Constructor,  Property、Method要添加特性[ ],override也分这几种
            IUnityContainer unityContainer = new UnityContainer();
            //单例
            unityContainer.RegisterSingleton<ICar, BMW>();
            //unityContainer.RegisterType<ICar, BMW>();
            Driver driver = unityContainer.Resolve<Driver>();
            driver.RunCar();
            driver.RunCar();
            //会覆盖前一个
            //unityContainer.RegisterSingleton<ICar, Ford>();
            //Driver driver2 = unityContainer.Resolve<Driver>();
            //至此一次override 容器中的ICar还是原来的ICar
            var driver2 = unityContainer.Resolve<Driver>(new Unity.Resolution.ParameterOverride("car", new Ford()));
            driver2.RunCar();
            ICar car = unityContainer.Resolve<ICar>();
             Console.WriteLine(car.Run());

            Console.ReadKey();
        }
    }
}
