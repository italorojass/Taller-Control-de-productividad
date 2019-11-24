using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControlProductividadCIISA.Models.ViewModels
{
    public class NuevOrigenViewModel
    {
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

    }
}