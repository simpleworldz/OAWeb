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
        
         //!!并不会执行这个??，要执行的话要加static，貌似这边用了Spring ??//
         //好吧 就连static也不行，加载方法里也不行。
       //static IBLL.IUserInfoService userInfoService = new BLL.UserInfoService();
        public ActionResult Index()
        {
            IBLL.IUserInfoService userInfoService = new BLL.UserInfoService();
            //也得理解下，其实 BLL.UserInfoService 就将Set<T> T 替换为 UserInfo了
            var userInfoList = userInfoService.LoadEntities(u => true);
            ViewData.Model = userInfoList;
            return View();
        }
    }
}