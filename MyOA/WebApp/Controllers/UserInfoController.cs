using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class UserInfoController : Controller
    {
        // GET: UserInfo
        //因为耦合，之后会用Spring改写

            //创建实例时会加载，如果加上static则创建实例或是使用静态方法时加载
            //且依据Nums的测试，加了static只执行一次，而不加，new()一次执行一次
        /*static */IBLL.IUserInfoService userInfoService = new BLL.UserInfoService();
        public ActionResult Index()
        {
            //IBLL.IUserInfoService userInfoService = new BLL.UserInfoService();
            //也得理解下，其实 BLL.UserInfoService 就将Set<T> T 替换为 UserInfo了
            var userInfoList = userInfoService.LoadEntities(u => true);
            ViewData.Model = userInfoList;
            return View();
        }
       
        //public static void testc()
        //{
        //    userInfoService.LoadEntities(u => true);
        //}
    }
}