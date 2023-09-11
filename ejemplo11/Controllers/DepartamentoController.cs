using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using ejemplo11.CN;
using ejemplo11.DAL;
using ejemplo11.Models;

namespace ejemplo11.Controllers
{
    public class DepartamentoController : Controller
    {
        departamentos odepartamentos = new departamentos();
        // GET: Departamento

        public ActionResult Index()
        {
            var lista = odepartamentos.Listar();
            return View(lista);
        }

        public ActionResult Listar()
        {
            List<Departamento> olista = new List<Departamento>();

            olista = new CN_departamentos().Listar(); //llamando a la capa de negocio

            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarDepartamentos(Departamento objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.ID == 0)
            {
                resultado = new CN_departamentos().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_departamentos().Editar(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarDepartamentos(int ID)
        {
            bool resultado = false;
            string mensaje = string.Empty;

            resultado = new CN_departamentos().Eliminar(ID, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int ID)
        {
            var lista = new CN_departamentos().Find(ID).FirstOrDefault();
            if (lista == null)
            {
                return RedirectToAction("Index");
            }
            return View("Details", lista);
        }



        // GET: Departamento/Details/5
        //public ActionResult Details(int ID)
        //{

        //    return View();

        //}

        // GET: Departamento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departamento/Create
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

        // GET: Departamento/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Departamento/Edit/5
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

        // GET: Departamento/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Departamento/Delete/5
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
