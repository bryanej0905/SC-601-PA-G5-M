using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SC_601_PA_G5_M.Models
{
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Fecha del pedido")]
        public DateTime FechaPedido { get; set; }

        [Required(ErrorMessage = "La identificación del cliente es obligatoria")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "El estado del pedido es obligatorio")]
        [StringLength(50)]
        public string EstadoPedido { get; set; }
    }
}