using ejemplo11.CN;
using ejemplo11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ejemplo11.Controllers
{
    public class TipoPreguntaController : Controller
    {
        // GET: TipoPregunta
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarTipoPregunta()
        {
            List<Tipo_Pregunta> olista = new List<Tipo_Pregunta>();

            olista = new CN_TipoPregunta().Listar(); //llamando a la capa de negocio

            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }

        // GET: TipoPregunta/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoPregunta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPregunta/Create
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

        // GET: TipoPregunta/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoPregunta/Edit/5
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

        // GET: TipoPregunta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoPregunta/Delete/5
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
