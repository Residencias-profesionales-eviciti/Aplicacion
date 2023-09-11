using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ejemplo11.CN;
using ejemplo11.DAL;
using ejemplo11.Models;

namespace ejemplo11.Controllers
{
    public class UsuarioController : Controller
    {
        Usuarios oUsuario = new Usuarios();

        // GET: Usuario
        public ActionResult Index()
        {
            var lista = oUsuario.Listar();
            return View(lista);
        }

        [HttpGet]
        public JsonResult ListarUsuarios()
        {
            List<Usuario> olista = new List<Usuario>();

            olista = new CN_Usuario().Listar(); //llamando a la capa de negocio

            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GuardarUsuario(Usuario objeto)
        {
            object resultado; //Debe ir solo la variable
            string Mensaje = string.Empty;

            if (objeto.IdUsuario == 0)
            {
                resultado = new CN_Usuario().Registrar(objeto, out Mensaje);
            }
            else
            {
                resultado = new CN_Usuario().Editar(objeto, out Mensaje);
            }

            return Json(new { resultado = resultado, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarUsuario(int id)
        {
            bool resultado = false;
            string mensaje = string.Empty;

            resultado = new CN_Usuario().Eliminar(id, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult Busqueda(Usuario ID)
        {
 
            var resultado = new CN_Usuario().Find(ID).FirstOrDefault();
            return Json(new { resultado = resultado }, JsonRequestBehavior.AllowGet);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
