using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LLV.Models;

namespace LLV.Controllers
{
    public class AcessoController : Controller
    {
        public ActionResult Login()
        {
            if (Session["logado"] != null)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioModel usuario)
        {
            string Mensagem = string.Empty;
            if (ModelState.IsValid)
            {
                if (usuario.EfetuaLogin(ref Mensagem))
                    return RedirectToAction("Index", "Home");

                ModelState.AddModelError(string.Empty, Mensagem);
            }
            return View();
        }

        public ActionResult Logoff()
        {
            if (Session["logado"] != null)
            {
                UsuarioModel usuario = (UsuarioModel)Session["logado"];
                usuario.EfetuaLogoff();
            }
            return RedirectToAction("Login", "Acesso");
        }
    }
}