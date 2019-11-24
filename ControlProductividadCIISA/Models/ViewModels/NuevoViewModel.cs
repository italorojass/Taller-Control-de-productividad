using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControlProductividadCIISA.Models.ViewModels
{
    public class NuevoViewModel
    {
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Required]
        
      

        [DataType(DataType.Date)]
     
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Fecha_inicio { get; set; }

        [DataType(DataType.Time)]
        public DateTime horainicio {get;set;}


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Final")]
        public DateTime Fecha_final { get; set; }


        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

      
    }
}