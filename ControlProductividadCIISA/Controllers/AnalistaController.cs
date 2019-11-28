using ControlProductividadCIISA.Models;
using ControlProductividadCIISA.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlProductividadCIISA.Controllers
{
    public class AnalistaController : Controller
    {
        // GET: Analista
        private ControlProductividadCIISAEntities db = new ControlProductividadCIISAEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SideBar()
        {

            return View();
        }
        
        public ActionResult CrearSolicitud()
        {
            return View();
        }
    }
}