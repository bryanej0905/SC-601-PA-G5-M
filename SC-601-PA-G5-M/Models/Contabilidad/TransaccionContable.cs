using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SC_601_PA_G5_M.Models.Taller;
using SC_601_PA_G5_M.Models.Ventas;

namespace SC_601_PA_G5_M.Models.Contabilidad
{
    public class TransaccionContable
    {
        [Key]
        public int IdTransaccion { get; set; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "La fecha es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime FechaTransaccion { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "El tipo de transacción es obligatorio")]
        public TipoTransaccion TipoTransaccion { get; set; }

        [Display(Name = "Monto")]
        [Required(ErrorMessage = "El monto es obligatorio")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal")]
        public decimal Monto { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(500)]
        public string Descripcion { get; set; }

        // Relaciones con otros modelos
        [Display(Name = "Cita Taller")]
        public int? CitaTallerId { get; set; }

        [Display(Name = "Producto")]
        public int? ProductoId { get; set; }

        // Propiedades de navegación
        [ForeignKey("CitaTallerId")]
        public virtual CitaTaller CitaTaller { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Producto Producto { get; set; }
    }

    public enum TipoTransaccion
    {
        [Display(Name = "Ingreso por Servicio")]
        IngresoServicio,
        [Display(Name = "Ingreso por Venta")]
        IngresoVenta,
        [Display(Name = "Otro Ingreso")]
        OtroIngreso,
        [Display(Name = "Gasto")]
        Gasto
    }
}
