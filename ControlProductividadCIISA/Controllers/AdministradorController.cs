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
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Permissions]
        public ActionResult CrearProyecto()
        {
            return View();
        }
    }
}