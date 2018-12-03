using IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DALFactory
{
    /// <summary>
    /// 抽象工厂：和工厂方法本质上是一样的，都解决对象创建问题。区别在于创建的方式不一样，抽象工厂是通过
    /// 反射的方式创建实例
    /// </summary>
    public class AbstractFactory
    {
        private static readonly string DalAssemblePath = ConfigurationManager.AppSettings["DalAssemblePath"];
        private static readonly string NameSpace = ConfigurationManager.AppSettings["NameSpace"];
        /// <summary>
        /// 创建  UserInfoDal实例
        /// </summary>
        /// <returns></returns>
        public static IUserInfoDal CreateUserInfoDal()
        {
            string fullClassName = NameSpace + ".UserInfoDal"; //".IUserInfoDal"; //无法创建interface的实例
            //return (IUserInfoDal)CreateInstance(fullClassName);
            return CreateInstance(fullClassName) as IUserInfoDal;
        }
        /// <summary>
        /// 反射
        /// </summary>
        /// <param name="fullClassName"></param>
        /// <returns></returns>
        public static object CreateInstance(string fullClassName)
        {
            var assemble = Assembly.Load(DalAssemblePath);
            return assemble.CreateInstance(fullClassName);
        }
    }
}
