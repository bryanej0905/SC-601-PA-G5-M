using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SC_601_PA_G5_M.Models.Taller
{
    public class CitaTaller
    {
        [Key]
        public int IdCita { get; set; }

        [ForeignKey("Usuario")]
        public string UsuarioId { get; set; }  // 🔄 string, no int

        public virtual ApplicationUser Usuario { get; set; }  // 👈 relacionado con Identity


        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de la cita")]
        public DateTime FechaCita { get; set; }


        [Required(ErrorMessage = "La descripcion del servicio es obligatorio")]
        [Display(Name = "Descripción Servicio")]
        [StringLength(100)]
        public string DescripcionServicio { get; set; }

        [Required(ErrorMessage = "El estado de la cita es obligatorio")]
        [Display(Name = "Estado de la cita")]
        [StringLength(50)]
        public string EstadoCita { get; set; }
    }
}