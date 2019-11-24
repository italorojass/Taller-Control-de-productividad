//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ControlProductividadCIISA.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Peticion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Peticion()
        {
            this.tbl_Estado_peticion = new HashSet<tbl_Estado_peticion>();
            this.tbl_LogFecha = new HashSet<tbl_LogFecha>();
            this.tbl_Peticion_usuario = new HashSet<tbl_Peticion_usuario>();
        }
    
        public int id { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> Nivel_impacto { get; set; }
        public Nullable<System.DateTime> Fecha_ingreso { get; set; }
        public Nullable<System.DateTime> Fecha_ejecucion { get; set; }
        public Nullable<System.DateTime> Fecha_finalizacion { get; set; }
        public Nullable<int> id_Usuario { get; set; }
        public Nullable<int> id_Origen { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Estado_peticion> tbl_Estado_peticion { get; set; }
        public virtual tbl_Origen tbl_Origen { get; set; }
        public virtual tbl_Usuario tbl_Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_LogFecha> tbl_LogFecha { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Peticion_usuario> tbl_Peticion_usuario { get; set; }
    }
}
