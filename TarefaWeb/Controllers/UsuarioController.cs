using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarefaWeb.Models;

namespace TarefaWeb.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario u)
        {
            using (UsuarioModel model = new UsuarioModel())
            {
               Usuario x =  model.Login(u.Email, u.Senha);
               if (x.Nome != null)
                {
                    Session["usuario"] = x.Nome;
                    Session["email"] = x.Email;
                    Session["receita"] = x.Receita;
                    return RedirectToAction("Index", "Produto", new { area = "" });
                }
            }
           
            return View(u);
        }

        public ActionResult Logout()
        {
            Session["usuario"] = null;
            Session["email"] = null;
            Session["receita"] = null;
            return RedirectToAction("Login");

        }

        // GET: Usuario
        [HttpGet]
        // GET: Tarefa
        public ActionResult Index()
        {
            using (UsuarioModel model = new UsuarioModel())
            {
                List<Usuario> lista = model.Read();
                return View(lista);

            } //model.Dispose();
        }

        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Usuario u)
        {
            if (ModelState.IsValid)
            {
                //u.Concluida = false;
                //u.Data = DateTime.Now;

                using (UsuarioModel model = new UsuarioModel())
                {
                    model.Create(u);
                    return RedirectToAction("Login");
                }
            }
            else
            {
                ViewBag.Erro = "Preencha corretamente as informações do usuário.";
                return View();
            }
        }

        public ActionResult Update(int id)
        {
            using (UsuarioModel model = new UsuarioModel())
            {
                return View(model.Read(id));
            }
        }

        [HttpPost]
        public ActionResult Update(int id, Usuario u)
        {
            if (ModelState.IsValid)
            {
                using (UsuarioModel model = new UsuarioModel())
                {
                    model.Update(u);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View(u);
            }
        }

        public ActionResult Delete(int id)
        {
            using (UsuarioModel model = new UsuarioModel())
            {
                model.Delete(id);
                return RedirectToAction("Index");
            }
        }
    }
}
