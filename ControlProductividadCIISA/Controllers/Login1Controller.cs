using ControlProductividadCIISA.Models;
using ControlProductividadCIISA.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlProductividadCIISA.Controllers
{
    public class Login1Controller : Controller
    {
        private ControlProductividadCIISAEntities db = new ControlProductividadCIISAEntities();
        // GET: Login1
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel form)
        {
            var query = from st in db.tbl_Usuario
                        where st.Correo == form.Email && st.Password == form.Password
                        select st;

            var data = query.FirstOrDefault();
           

            if (data!= null)
            {
                Session["User"] = data;
                Session["UserLogin"] = data.Nombre + " " + data.Apellido;
                Session["UserRol"] = data.tbl_Rol.Descripcion;
                Session["UserRolID"] = data.Id_rol;
                if (data.Id_rol == 1)
                {
                    return RedirectToAction("Index", "Administrador");
                }
                else
                {
                    return RedirectToAction("Index", "Analista");
                }
                
            }
            else
            {
                ViewBag.noexiste = "No existe el usuario";
                return View();
            }
           

           
        }
    }
}