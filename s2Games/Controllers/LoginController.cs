#region using

using s2Games.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

#endregion

namespace s2Games.Controllers
{
    public class LoginController : Controller
    {
        #region Index
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(user usuario)
        {
            ViewBag.Mensagem = "";
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new dbGame())
                    {
                        var retorno = db.users.Count(u => u.login.Equals(usuario.login) && u.senha.Equals(usuario.senha));

                        if (retorno > 0)
                        {
                            Session["user"] = retorno;
                            return RedirectToAction("Index", "Home");
                        }
                        else
                            ViewBag.Mensagem = "Usuario ou senha incorretos";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao realizar Login: " + ex.Message);
            }
            
           return View("Index");
        }
        #endregion

        #region Logout
        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "Login");
        }
        #endregion
    }
}