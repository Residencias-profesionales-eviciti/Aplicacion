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
    public class EncuestaPreguntaController : Controller
    {
        EncuestaPreguntas oEncuestaPreguntas = new EncuestaPreguntas();

        // GET: EncuestaPregunta
        public ActionResult Index()
        {
            var lista = oEncuestaPreguntas.Listar();
            return View(lista);
        }

        public JsonResult ListarEncuestaPregunta()
        {
            List<Encuesta_Pregunta> olista = new List<Encuesta_Pregunta>();

            olista = new CN_EncuestaPregunta().Listar(); //llamando a la capa de negocio

            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarEncuestaPregunta(Encuesta_Pregunta objeto)
        {
            object resultado; //Debe ir solo la variable
            string Mensaje = string.Empty;

            if (objeto.IdEncuesta_pregunta == 0)
            {
                resultado = new CN_EncuestaPregunta().Registrar(objeto, out Mensaje);
            }
            else
            {
                resultado = new CN_EncuestaPregunta().Editar(objeto, out Mensaje);
            }

            return Json(new { resultado = resultado, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);
        }


        // GET: EncuestaPregunta/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EncuestaPregunta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EncuestaPregunta/Create
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

        // GET: EncuestaPregunta/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EncuestaPregunta/Edit/5
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

        // GET: EncuestaPregunta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EncuestaPregunta/Delete/5
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
