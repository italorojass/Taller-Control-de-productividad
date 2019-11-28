using ControlProductividadCIISA.Models;
using ControlProductividadCIISA.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlProductividadCIISA.Controllers
{
    public class AdministradorController : Controller
    {
        // GET: Administrador
        private ControlProductividadCIISAEntities db = new ControlProductividadCIISAEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUsuariosResumen()
        {
            var query = from it in db.tbl_Usuario
                        select it;
            return Json("ok");
        }
        
        public ActionResult CrearProyecto()
        {
            return View();
        }
    }
}