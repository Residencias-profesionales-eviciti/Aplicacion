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
    public class EncuestaController : Controller
    {
        Encuestas oEncuestas = new Encuestas();

        // GET: Encuesta
        public ActionResult Index()
        {
            var lista = oEncuestas.Listar();
            return View(lista);
        }

        [HttpGet]
        public JsonResult ListarEncuesta()
        {
            List<Encuesta> olista = new List<Encuesta>();

            olista = new CN_Encuesta().Listar(); //llamando a la capa de negocio

            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarEncuesta(Encuesta objeto)
        {
            object resultado; //Debe ir solo la variable
            string Mensaje = string.Empty;

            if (objeto.IdEncuesta == 0)
            {
                resultado = new CN_Encuesta().Registrar(objeto, out Mensaje);
            }
            else
            {
                resultado = new CN_Encuesta().Editar(objeto, out Mensaje);
            }

            return Json(new { resultado = resultado, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarEncuesta(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Encuesta().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int ID)
        {
            var lista = new CN_Encuesta().Find(ID).FirstOrDefault();
            var query = "select * from Encuesta where IdEncuesta = " + ID;

            if (lista == null)
            {
                return RedirectToAction("Index");

            }
            return View("Details", lista);
        }


        // GET: Encuesta/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Encuesta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Encuesta/Create
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

        // GET: Encuesta/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Encuesta/Edit/5
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

        // GET: Encuesta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Encuesta/Delete/5
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
