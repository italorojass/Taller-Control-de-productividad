using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControlProductividadCIISA.Models;
using ControlProductividadCIISA.Models.ViewModels;

namespace ControlProductividadCIISA.Controllers
{
    public class ProyectosController : Controller
    {
        // GET: Proyectos
        public ActionResult Index()
        {
            List<ListProyectosViewModel> lst;
            using (ControlProductividadCIISAEntities db = new ControlProductividadCIISAEntities())

            {
                lst = (

                   from d in db.tbl_Proyectos
                   join o in db.tbl_Origen on d.id equals o.id_proyecto

                   select new ListProyectosViewModel

                   {
                       id = d.id,
                       Nombre = o.Nombre,
                       Descripcion = d.Descripcion,
                       Fecha_inicio = d.Fecha_inicio,
                       Fecha_final = d.Fecha_final

                   }).ToList();


            }

            return View(lst);
        }

        public ActionResult Nuevo()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(NuevoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ControlProductividadCIISAEntities db = new ControlProductividadCIISAEntities())
                    {
                        var nue = new tbl_Proyectos();
                        var nueo = new tbl_Origen();

                        var fechainicio = new DateTime(model.Fecha_inicio.Year, model.Fecha_inicio.Month, model.Fecha_inicio.Day,                        model.horainicio.Hour, model.horainicio.Minute, model.horainicio.Second);

                        nue.Fecha_final = Convert.ToDateTime(fechainicio.ToString());
                        nueo.id_proyecto = nue.id;
                        nueo.Nombre = model.Nombre;
                        nue.Descripcion = model.Descripcion;
                        // nue.Fecha_inicio = model.Fecha_inicio.AddHours(model.Fecha_inicio.Hour).AddMinutes(model.Fecha_inicio.Minute).AddSeconds(model.Fecha_inicio.Second);
                        // nue.Fecha_final = model.Fecha_final;
                        db.tbl_Proyectos.Add(nue);
                        db.tbl_Origen.Add(nueo);
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

        public ActionResult Editar(int? id)
        {
            NuevoViewModel model = new NuevoViewModel();
            using (ControlProductividadCIISAEntities db = new ControlProductividadCIISAEntities())

            {
                var rnuevo = db.tbl_Proyectos.Find(id);
                var nueoo = db.tbl_Origen.Find(id);
                model.Nombre = nueoo.Nombre;
                model.Descripcion = rnuevo.Descripcion;
                model.Fecha_inicio = rnuevo.Fecha_inicio;
                model.Fecha_final = rnuevo.Fecha_final;
                model.id = nueoo.id;
                model.id = rnuevo.id;

            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(NuevoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ControlProductividadCIISAEntities db = new ControlProductividadCIISAEntities())
                    {
                        var nue = new tbl_Proyectos();
                        var nueo = new tbl_Origen();
                        nueo.id_proyecto = nue.id;
                        nueo.Nombre = model.Nombre;
                        nue.Descripcion = model.Descripcion;
                        nue.Fecha_inicio = model.Fecha_inicio;
                        nue.Fecha_final = model.Fecha_final;
                        db.tbl_Proyectos.Add(nue);

                        db.Entry(nueo).State = System.Data.Entity.EntityState.Modified;
                        db.Entry(nue).State = System.Data.Entity.EntityState.Modified;
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