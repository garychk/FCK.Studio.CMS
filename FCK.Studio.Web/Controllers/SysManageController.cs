using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FCK.Studio.Web.Controllers
{
    public class SysManageController : Controller
    {
        // GET: SysManage
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logs()
        {
            return View();
        }
        public ActionResult Admins()
        {
            return View();
        }
        public ActionResult Databack()
        {
            return View();
        }
    }
}