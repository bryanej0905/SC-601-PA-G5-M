using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SC_601_PA_G5_M.Models.Taller;

namespace SC_601_PA_G5_M.Models.Contabilidad
{
    public class Transaccion
    {
        [Key]
        public int IdTransaccion { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Fecha de la cita")]
        public DateTime FechaTransaccion { get; set; }

        [Required(ErrorMessage = "El tipo de transaccion es obligatorio")]
        [StringLength(25)]
        public string TipoTransaccion { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatoria")]
        [StringLength(100)]
        public string DescripcionTransaccion { get; set; }

        [Required(ErrorMessage = "El monto de la transaccion es obligatorio")]
        public double MontoTransaccion { get; set; }
    }
}