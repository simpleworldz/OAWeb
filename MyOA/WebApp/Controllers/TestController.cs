using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
       //同Test.Nums中的一样，static只会执行一次，所以即使不同用户访问，它都会在前一个
       //用户的基础上++
        int num1 = 1;
        static int num2 = 1;
        public ActionResult Index()
        {
            num1++;
            num2++;
            ViewBag.num1 = num1;
            ViewBag.num2 = num2;
            return View();
        }
    }
}