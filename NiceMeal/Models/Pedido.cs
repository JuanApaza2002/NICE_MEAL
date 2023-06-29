using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceMeal.Models
{
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }
        [Required]
        public string NombrePedido { get; set; }
        [Required]
        public string NumeroPedido { get; set; }

        //clave foranea
        //muchos pedidos tiene un usuario
        public Usuario Usuario { get; set; }

        //clave foranea
        //muchos pedidos realiza un cliente
        public Cliente Cliente { get; set; }

        //integridad referencial
        //un pedido tiene muchos detalles
        public List<Detalle> Detalles { get; set;}
    }
}
