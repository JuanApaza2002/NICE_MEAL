using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NiceMeal.Vistas
{
    public partial class FrmMenuPrincipal : Form
    {
        String _usuario;
        public FrmMenuPrincipal(string usuario)
        {
            InitializeComponent();
            _usuario = usuario;
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = _usuario;
        }

        private void gESTIONARUSUARIOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmGestionarUsuario frmGestionarUsuario = new FrmGestionarUsuario();
            frmGestionarUsuario.IsMdiContainer = true;
            frmGestionarUsuario.WindowState = FormWindowState.Maximized;
            frmGestionarUsuario.Show();
        }

        private void registrarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGestionarCliente frmGestionarCliente = new FrmGestionarCliente();
            frmGestionarCliente.IsMdiContainer = true;
            frmGestionarCliente.WindowState = FormWindowState.Maximized;
            frmGestionarCliente.Show();
        }

        private void lISTARMENUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListarMenu frmListarMenu = new FrmListarMenu();
            frmListarMenu.IsMdiContainer = true;
            frmListarMenu.WindowState = FormWindowState.Maximized;
            frmListarMenu.Show();
        }
    }
}
