using ControlProductividadCIISA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlProductividadCIISA.Controllers
{
    public class UsuarioController : Controller
    {
        private ControlProductividadCIISAEntities db = new ControlProductividadCIISAEntities();
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Crear() //vista del formulario
        {

            var User = new tbl_Usuario();
           
            User.Nombre = "prueba";
            User.Id_rol = 1;
           

            db.tbl_Usuario.Add(User);

            db.SaveChanges();

            return View();
        }

        [HttpPost]
        public ActionResult Crear(Models.tbl_Usuario form) {
            var User = new tbl_Usuario();
            User.Nombre = form.Nombre;
            User.Id_rol = 1;



            db.tbl_Usuario.Add(User);

            db.SaveChanges();

            return Json("") ;
        }
    }
}