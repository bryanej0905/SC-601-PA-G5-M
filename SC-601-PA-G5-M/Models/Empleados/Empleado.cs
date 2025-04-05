using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SC_601_PA_G5_M.Models.Taller;

namespace SC_601_PA_G5_M.Models.Empleados
{
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }

        [Required(ErrorMessage = "El nombre del empleado es obligatorio")]
        [StringLength(100)]
        public string NombreEmpleado { get; set; }

        [Required(ErrorMessage = "El puesto del empleado es obligatorio")]
        [StringLength(50)]
        public string PuestoEmpleado { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Fecha de contratacion")]
        public DateTime FechaContratacion { get; set; }

        [Required(ErrorMessage = "El salario del empleado es obligatorio")]
        public double Salario { get; set; }
    }
}