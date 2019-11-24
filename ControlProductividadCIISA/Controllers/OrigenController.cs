using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControlProductividadCIISA.Models;
using ControlProductividadCIISA.Models.ViewModels;

namespace ControlProductividadCIISA.Controllers
{
    public class OrigenController : Controller
    {
        // GET: Origen
        public ActionResult Index()
        {
            List<OrigenModel> lst;
            using (ControlProductividadCIISAEntities db = new ControlProductividadCIISAEntities())

            {
                lst = (from d in db.tbl_Origen
                       select new OrigenModel

                       {
                           id = d.id,
                           Nombre = d.Nombre                            
                       }).ToList();
                
            }

            return View(lst);
        }

        public ActionResult Nuevo()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(NuevOrigenViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ControlProductividadCIISAEntities db = new ControlProductividadCIISAEntities())
                    {
                        var nue = new tbl_Origen();
                        nue.Nombre = model.Nombre;
                      
                        db.tbl_Origen.Add(nue);
                        db.SaveChanges();
                    }

                    return Redirect("/");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


    }

}