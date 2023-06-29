using NiceMeal.Context;
using NiceMeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceMeal.Controladores
{
    internal class ClienteController
    {
        //CRUD del Cliente
        ModelRestaurante _context = new ModelRestaurante();


        //CRUD 
        //Devuelva Todos los Clientes
        public List<Cliente> GetAll()
        {
            return _context.Cliente.ToList();
        }

        //Para que devuelva solo un Cliente a traves del Primary Key
        public Cliente Get(int IdCliente)
        {
            return _context.Cliente.Find(IdCliente);
        }

        //Buscar
        public List<Cliente> Search(String par)
        {
            if (String.IsNullOrEmpty(par))
            {
                return GetAll();
            }
            else
            {
                //Pe Devolver Perez 
                //Da Devolver Daniel,David,Danilo
                return _context.Cliente.Where(x => x.NombreCliente.Contains(par)).ToList();
            }
        }


        //Crear, Actualizar y Eliminar

        public bool Create(Cliente cliente)
        {
            _context.Cliente.Add(cliente); //Agregando a la tabla Usuario
            return _context.SaveChanges() > 0; //Guardando cambios en la base de datos
        }

        public bool Update(Cliente cliente)
        {
            _context.Cliente.Attach(cliente); //Buscar en la tabla Usuario
            _context.Entry(cliente).State = System.Data.Entity.EntityState.Modified; //Modifique al Usuario En la BBDD
            return _context.SaveChanges() > 0; //Guardando cambios en la base de datos
        }

        public bool Delete(Cliente cliente)
        {
            _context.Cliente.Remove(cliente); //Buscar y lo va eliminar en la BBDD
            return _context.SaveChanges() > 0; //Guardando cambios en la base de datos
        }
    }
}
