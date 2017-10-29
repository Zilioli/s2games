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
    public class AmigoController : Controller
    {
        #region Index
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region ListarAmigos
        [HttpGet]
        public PartialViewResult ListarAmigos()
        {
            List<amigo> listaAmigos = new List<amigo>();

            try
            {
                using (var db = new dbGame())
                {
                    listaAmigos = db.amigos.Where(s => s.dataExclusao == null).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar Amigo" + ex.Message);
            }

            return PartialView(listaAmigos);
        }
        #endregion

        #region ExcluirAmigo
        [HttpGet]
        public void ExcluirAmigo(int codigo)
        {
            try
            {
                using (var db = new dbGame())
                {
                    amigo amigo = db.amigos.First(e => e.codigo.Equals(codigo));
                    amigo.dataExclusao = DateTime.Now;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir Amigo" + ex.Message);
            }
        }
        #endregion

        #region ManutencaoAmigos
        [HttpGet]
        public PartialViewResult ManutencaoAmigos()
        {
            amigo amigo= JsonConvert.DeserializeObject<amigo>(Request.Params[0]);

            return PartialView(amigo);
        }
        #endregion

        #region Salvar
        [HttpPost]
        public JsonResult Salvar(amigo amigo)
        {
            try
            {
                using (var db = new dbGame())
                {
                    if (amigo.codigo > 0)
                    {
                        var novoGame = db.amigos.First(e => e.codigo.Equals(amigo.codigo));
                        novoGame.nome = amigo.nome;
                    }
                    else
                        db.amigos.Add(amigo);

                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json("OK");
        }
        #endregion
    }
}