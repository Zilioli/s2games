#region using

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using s2Games.Models;

#endregion

namespace s2Games.Controllers
{
    public class HomeController : Controller
    {
        #region Index
        public ActionResult Index()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar Painel de Controle: " + ex.Message);
            }

            return View();
        }
        #endregion

        #region Listar
        [HttpGet]
        public PartialViewResult Listar()
        {
            List<emprestimo> listaEmprestimo = new List<emprestimo>();
            using (var db = new dbGame())
            {
                listaEmprestimo = db.emprestimos.
                    Where(e => e.dataDevolucao == null).ToList();

                foreach (emprestimo emp in listaEmprestimo)
                {
                    emp.amigo = db.amigos.Where(e => e.codigo == emp.codigoAmigo).SingleOrDefault();
                    emp.game = db.games.Where(g => g.codigo == emp.codigoGame).SingleOrDefault();
                }

            }

            return PartialView(listaEmprestimo);
        }
        #endregion

        #region EmprestarGame

        [HttpGet]
        public PartialViewResult EmprestarGame()
        {
            var db = new dbGame();

            ViewBag.listaAmigos = db.amigos.Where(a => a.dataExclusao == null).ToList();

            // Lista de jogos disponíveis que não estão emprestados para outro amigo
            ViewBag.listaGames = from g in db.games
                                 where !(from e in db.emprestimos
                                         where e.dataDevolucao == null
                                         select e.codigoGame).Contains(g.codigo)
                                 && g.dataExclusao == null
                                 select g;

            return PartialView();

        }

        #endregion

        #region Emprestar
        [HttpPost]
        public JsonResult Emprestar(emprestimo emprestimo)
        {

            try
            {
                using (var db = new dbGame())
                {
                    emprestimo.dataEmprestimo = DateTime.Now;
                    db.emprestimos.Add(emprestimo);

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao realizar emprestimo do game: " + ex.Message);
            }

            return Json("OK");
        }
        #endregion

        #region Devolver
        [HttpPost]
        public JsonResult Devolver(int codigoAmigo, int codigoGame)
        {

            try
            {
                using (var db = new dbGame())
                {
                    emprestimo emprestimo =
                        db.emprestimos.Where(e => e.codigoGame.Equals(codigoGame) &&
                        e.codigoAmigo.Equals(codigoAmigo)).SingleOrDefault();

                    if (emprestimo != null)
                    {
                        emprestimo.dataDevolucao = DateTime.Now;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao realizar emprestimo do game: " + ex.Message);
            }

            return Json("OK");
        }
        #endregion
    }
}