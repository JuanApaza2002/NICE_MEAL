using NiceMeal.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace NiceMeal.Context
{
    public partial class ModelRestaurante : DbContext
    {
        public ModelRestaurante()
            : base("name=ModelRestaurante")
        {
        }
        //mapear a la base de datos
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Detalle> Detalle { get; set; }
        public virtual DbSet<Compra> Compra { get; set; }
    }
}
