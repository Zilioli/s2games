#region using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using s2Games.Models;
using Newtonsoft.Json;

#endregion

namespace s2Games.Controllers
{
    public class GameController : Controller
    {
        #region Index
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region ListarGames
        [HttpGet]
        public PartialViewResult ListarGames()
        {
            List<game> listaGames = new List<game>();

            try
            {
                using (var db = new dbGame())
                {
                    listaGames = db.games.Where(s => s.dataExclusao == null).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar Games" + ex.Message);
            }

            return PartialView(listaGames);
        }

        #endregion

        #region ExcluirGame
        [HttpGet]
        public void ExcluirGame(int codigo)
        {  
            try
            {
                using (var db = new dbGame())
                {
                    game game = db.games.First(e => e.codigo.Equals(codigo));
                    game.dataExclusao = DateTime.Now;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir Games" + ex.Message);
            }
        }

        #endregion

        #region ManutencaoGames
        [HttpGet]
        public PartialViewResult ManutencaoGames()
        {
            game game = JsonConvert.DeserializeObject<game>(Request.Params[0]);
     
            return PartialView(game);
        }

        #endregion

        #region Salvar
        [HttpPost]
        public JsonResult Salvar(game game)
        {
            try
            {
                using (var db = new dbGame())
                {
                    if (game.codigo > 0)
                    {
                        var novoGame = db.games.First(e => e.codigo.Equals(game.codigo));
                        novoGame.nome = game.nome;
                    }
                    else
                        db.games.Add(game);

                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json( "OK");
        }
        #endregion
    }
}