using ejemplo11.CN;
using ejemplo11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using ejemplo11.DAL;


namespace ejemplo11.Controllers
{
    public class TipoUsuarioController : Controller
    {
        TipoUsuario oUsuario = new TipoUsuario();

        // GET: TipoUsuario
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarTipoUsuario()
        {
            List<tipo_usuario> olista = new List<tipo_usuario>();

            olista = new CN_TipoUsuario().Listar(); //llamando a la capa de negocio

            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }


        // GET: TipoUsuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoUsuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoUsuario/Create
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

        // GET: TipoUsuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoUsuario/Edit/5
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

        // GET: TipoUsuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoUsuario/Delete/5
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
