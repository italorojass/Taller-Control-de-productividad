using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlProductividadCIISA.Models.ViewModels
{
    public class ListProyectosViewModel
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_inicio { get; set; }
        public DateTime Fecha_final { get; set; }
        public int ido { get; set; }

        public int idproy { get; set; }


    }
}
