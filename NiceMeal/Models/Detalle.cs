using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceMeal.Models
{
    public class Detalle
    {
        [Key]
        public int IdDetalle { get; set; }
        [Required]
        public DateTime FechaDetalle { get; set; }
        [Required]
        public int CantidadDetalle { get; set; }
        [Required]
        public int CostoDetalle { get; set; }
        [Required]
        public int TotalDetalle { get; set; }

        //clave foranea
        //muchos detalles tiene un pedido
        public Pedido Pedido { get; set; }

        //clave foranea
        //muchos detalles tiene un producto
        public Producto Producto { get; set; }
    }
}
