using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceMeal.Models
{
    public class Compra
    {
        [Key]
        public int IdCompras { get; set; }
        [Required]
        public string NombreCompra { get; set;}
        [Required]
        public string DescripcionCompra { get; set;}
        [Required]
        public DateTime FechaCompra { get; set; }
        [Required]
        public int CantidadCompra { get; set; }
        [Required]
        public int PrecioCompra { get; set; }
        [Required]
        public DateTime VencimientoCompra { get; set; }

        //clave foranea
        //muchos compras tiene un usuario
        public Usuario Usuario { get; set; }
    }
}
