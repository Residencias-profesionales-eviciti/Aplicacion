using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using ejemplo11.Models;
using ejemplo11.CN;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Claims;

namespace ejemplo11.Controllers
{
    public class LoginController : Controller
    {
        string cn = ConfigurationManager.ConnectionStrings["DBSISTEMAstring"].ToString();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Index(string correo, string clave)
        //{
        //    Usuario oUsuario = new Usuario();

        //    oUsuario = new CN_Usuario().Listar().Where(u => u.Correo == correo && u.Clave == clave).FirstOrDefault();

        //    if (oUsuario == null)
        //    {
        //        ViewBag.Error = "Correo o contraseña no correcta";
        //        return View();
        //    }

        //    else
        //    {
        //        FormsAuthentication.SetAuthCookie(oUsuario.Correo, false);

        //        ViewBag.Error = null;

        //        return RedirectToAction("Index", "Home");
        //    }

        

        [HttpPost]
        public ActionResult Index(Usuario oUsuario)
        {
            using (SqlConnection oConexion = new SqlConnection(cn))
            {
                SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", oConexion);
                cmd.Parameters.AddWithValue("Correo", oUsuario.Correo);
                cmd.Parameters.AddWithValue("Clave", oUsuario.Clave);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                oConexion.Open();

                oUsuario.IdUsuario = Convert.ToInt32(cmd.ExecuteScalar());

            }
            if(oUsuario.IdUsuario != 0)
            {
                FormsAuthentication.SetAuthCookie(oUsuario.Correo, false);
                Session["Usuario"] = oUsuario;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Mensaje"] = "Correo o contraseña no correcta";
                return View();
            }
        }



        //public ActionResult CerrarSesion()
        //{
        //    //FormsAuthentication.SignOut();
        //    //Session["Usuario"] = null;
        //    return RedirectToAction("Index", "Login");
        //}


        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
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

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
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

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
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
