using NiceMeal.Context;
using NiceMeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NiceMeal.Controladores
{
    internal class UsuarioController
    {
        //CRUD y LOGIN
        ModelRestaurante _context = new ModelRestaurante();

        public bool Login(string usuario, string password)
        {
            var UsuarioLogin = _context.Usuario.Where(x => x.CuentaUsuario == usuario
               && x.Password == password).SingleOrDefault();
            if (UsuarioLogin != null) {
                return true;
            }
            else
                return false;
        }
        //CRUD
        //Devuelva Todos los usuarios
        public List<Usuario> GetAll()
        {
          return _context.Usuario.ToList();
        }
        //Para que devuelva solo un usuario a traves de primary key
        public Usuario Get(string CuentaUsuario) 
        {
            return _context.Usuario.Find(CuentaUsuario);
        }

        //Buscar 
        public List<Usuario> Search(string par)
        {
            if(string.IsNullOrEmpty(par))
            {
                return GetAll();
            }
            else
            {
                //Pe devolver Perez
                //Da devolver daniel, david, danilo
                return _context.Usuario.Where(x => x.CuentaUsuario.Contains(par) || 
                x.NombreUsuario.Contains(par)).ToList();
            }
        }
        //Crear, Actualizar y Eliminar

        public bool Create(Usuario usuario)
        {
            _context.Usuario.Add(usuario); //Agregando a la tabla Usuario
            return _context.SaveChanges() > 0; //Guardando cambios en la base de datos
        }

        public bool Update(Usuario usuario)
        {
            _context.Usuario.Attach(usuario); //Buscar en la tabla Usuario
            _context.Entry(usuario).State = System.Data.Entity.EntityState.Modified; //Modifique al Usuario En la BBDD
            return _context.SaveChanges() > 0; //Guardando cambios en la base de datos
        }

        public bool Delete(Usuario usuario)
        {
            _context.Usuario.Remove(usuario); //Buscar y lo va eliminar en la BBDD
            return _context.SaveChanges() > 0; //Guardando cambios en la base de datos
        }
    }
}
