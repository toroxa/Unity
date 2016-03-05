using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LLV.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["logado"] == null)
                return RedirectToAction("Login", "Acesso");
            else
                return View();
        }

        public ActionResult Parametro()
        {
            if (Session["logado"] == null)
                return RedirectToAction("Login", "Acesso");
            else
                return PartialView();
        }

        public ActionResult Home()
        {
            if (Session["logado"] == null)
                return RedirectToAction("Login", "Acesso");
            else
                return PartialView();
        }
    }
}