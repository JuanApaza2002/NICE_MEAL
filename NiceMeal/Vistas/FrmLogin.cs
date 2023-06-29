using NiceMeal.Context;
using NiceMeal.Controladores;
using NiceMeal.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NiceMeal
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //Sirve para crear las clases a la base de datos 
            //ModelRestaurante db = new ModelRestaurante();
            //var usuario = db.Usuario.ToList();
            //var cliente = db.Cliente.ToList();
            //var producto = db.Producto.ToList();
            //var pedido = db.Pedido.ToList();
            //var detalle = db.Detalle.ToList();
            //var compra = db.Compra.ToList();
        }

        private void btn_iniciar_Click(object sender, EventArgs e)
        {
            string usuario = txt_usuario.Text;
            string password = txt_password.Text;
            UsuarioController usuariocontroller = new UsuarioController();
            bool isLogin = usuariocontroller.Login(usuario, password);
            if(isLogin == true)
            {
              //Pantalla Menu Principal
              FrmMenuPrincipal frmMenuPrincipal = new FrmMenuPrincipal(usuario);
               frmMenuPrincipal.Show();
            }
            else
            {
                MessageBox.Show("Usuario o Password Incorrectos",
                    "Restaurante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
