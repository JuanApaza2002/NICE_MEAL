using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceMeal.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        [Required]
        public string NombreProducto { get; set; }
        [Required]
        public string DescripcionProducto { get; set; }
        [Required]
        public string TipoProducto { get; set; }
        [Required]
        public int CantidadProducto { get; set;}
        [Required]
        public bool StockProducto { get; set; }
        [Required]
        public string PrecioProducto { get; set; }


        //integridad referencial
        //un producto registra muchos detalles
        public List<Detalle> Detalle { get; set; }
    }
 }
