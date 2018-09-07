using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarefaWeb.Models;

namespace TarefaWeb.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Usuario
        [HttpGet]
        public ActionResult Index()
        {
            using (ProdutoModel model = new ProdutoModel())
            {
                List<Produto> lista = model.Read();
                return View(lista);

            } //model.Dispose();
        }

        public ActionResult View(int id)
        {
            using (ProdutoModel model = new ProdutoModel())
            {
                Produto lista = model.View(id);
                return View(lista);

            }
        }


        public ActionResult Buy(Produto p)
        {
            using (ProdutoModel model = new ProdutoModel())
            {
                decimal preco = model.Buy(p, (string)Session["email"]);

                Session["receita"] = preco;
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            UsuarioModel u = new UsuarioModel();

            ViewBag.Usuarios = u.Read();

            return View();
        }

        [HttpPost]
        public ActionResult Create(Produto p)
        {
            if (ModelState.IsValid)
            {
                using (ProdutoModel model = new ProdutoModel())
                {
                    model.Create(p);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.Erro = "Preencha corretamente as informações do produto.";
                return RedirectToAction("Index");
            }
        }

        public ActionResult Update(int id)
        {
            using (ProdutoModel model = new ProdutoModel())
            {
                return View(model.View(id));
            }
        }

        [HttpPost]
        public ActionResult Update(int id, Produto p)
        {
            if (ModelState.IsValid)
            {
                using (ProdutoModel model = new ProdutoModel())
                {
                    model.Update(p);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View(p);
            }
        }

        public ActionResult Delete(int id)
        {
            using (ProdutoModel model = new ProdutoModel())
            {
                model.Delete(id);
                return RedirectToAction("Index");
            }
        }
    }
}