using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LLV.Controllers
{
    public class VendaRapidaController : Controller
    {
        public ActionResult Index()
        {
            if (Session["logado"] == null)
                return RedirectToAction("Login", "Acesso");
            else
                return PartialView();
        }
    }
}