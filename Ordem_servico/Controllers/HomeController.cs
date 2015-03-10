using Ordem_servico.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ordem_servico.Controllers
{
    public class HomeController : Controller
    {
        [SessionAuthorize]
        public ActionResult Index()
        {
            ViewBag.Title = "Principal - TRS Sistemas";
            return View();
        }
    }
}
