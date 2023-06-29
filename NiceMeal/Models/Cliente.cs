using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceMeal.Models
{
    public class Cliente
    {
      [Key]
      public int IdCliente { get; set; }
      [Required]
      public string NombreCliente { get; set; }
      [Required]
      public int CiCliente { get; set; }
      [Required]
      public int CelularCliente { get; set; }

        //integridad referencial
        //un usuario registra muchos Pedidos
        public List<Pedido> Pedidos { get; set; }
    }
}
