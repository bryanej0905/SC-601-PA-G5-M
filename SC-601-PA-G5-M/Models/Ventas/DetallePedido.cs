using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SC_601_PA_G5_M.Models
{
    public class DetallePedido
    {
        [Key]
        public int IdDetallePedidop { get; set; }

        [ForeignKey("Pedido")]

        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }

        [ForeignKey("Producto")]
        public int ProductoId { get; set; }
        public virtual Producto Producto { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El precio unitario es obligatorio")]
        public double PrecioUnitario { get; set; }
    }
}