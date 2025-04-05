using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SC_601_PA_G5_M.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [StringLength(100)]
        public string NombreProducto { get; set; }

        [Required(ErrorMessage = "La descripcion del producto es obligatorio")]
        [StringLength(100)]
        public string DescripcionProducto { get; set; }

        [Required(ErrorMessage = "El precio del producto es obligatorio")]
        public double PrecioProducto { get; set; }

        [Required(ErrorMessage = "La cantidad de existencias es obligatorio")]
        public int Existencias { get; set; }
    }
}