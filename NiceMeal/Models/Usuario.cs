using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceMeal.Models
{
    //la calse tiene que ser public
    public class Usuario
    {
        [Key]
        public string CuentaUsuario { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string NombreUsuario { get; set; }
        [Required]
        public bool EstadoUsuario { get; set; }

        //integridad referencial
        //un usuario registra muchos Pedidos
        public List<Pedido> Pedidos { get; set; }


        //integridad referencial
        //un usuario registra muchas Compras
        public List<Compra> Compra { get; set; }
    }
}
