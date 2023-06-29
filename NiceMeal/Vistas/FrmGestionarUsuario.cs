using NiceMeal.Controladores;
using NiceMeal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NiceMeal.Vistas
{
    public partial class FrmGestionarUsuario : Form
    {
        public FrmGestionarUsuario()
        {
            InitializeComponent();
        }
        UsuarioController _usuarioController = new UsuarioController();
        //Para saber si el usuario es nuevo o estamos modificando al usuario
        bool _isNew = true;
        private void button4_Click(object sender, EventArgs e)
        {
            string par = txtBuscar.Text;
            //Que en el DataGridView Muestre todos los usuarios que cumplan con el paramatro "par"
            usuarioBindingSource.DataSource = _usuarioController.Search(par);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        public void Guardar()
        {
            var user = (Usuario)usuarioBindingSource.Current;
            if(_isNew == true )
            {
                _usuarioController.Create(user);
            }
            else
            {
                _usuarioController.Update(user);
            }
            //deshabilite los atributos (TextBox, CheckBox) para agregar o modificar un usuario
            groupBoxUsuario.Enabled = false;
            //actualice el datagridview
            usuarioBindingSource.DataSource = _usuarioController.GetAll();
        }

        private void FrmGestionarUsuario_Load(object sender, EventArgs e)
        {
            //cuando cargue la pantalla muestre en el datagridview todos los usuarios de bbdd
            usuarioBindingSource.DataSource = _usuarioController.GetAll();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //deshabilite los atributos (TextBox, CheckBox) para agregar o modificar un usuario
            groupBoxUsuario.Enabled = false;
            //elimine todo lo que se escribio en los atributos (TextBox, CheckBox) del usuario
            usuarioBindingSource.CancelEdit();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //Variable Global _isNew sea True
            _isNew = true;
            //Habilite el GroupBox para escribir en los atributos (Textbox,Checkbox)
            groupBoxUsuario.Enabled = true;
            //Borre todo lo que antes estaba escrito para escribir los nuevos datos en los atributos (Textbox,Checkbox)
            usuarioBindingSource.AddNew();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Recuperar todo lo seleccionado del Usuario en el DataGridView
            var user = (Usuario)usuarioBindingSource.Current;
            //Mensaje 
            DialogResult dlr = MessageBox.Show("Estas Seguro de Eliminar?",
                "Restaurante",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);
            //Si yo apreto Ok
            if (dlr == DialogResult.OK)
            {
                _usuarioController.Delete(user);
            }
            //Actualice el DataGridView 
            usuarioBindingSource.DataSource = _usuarioController.GetAll();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Variable Global _isNew sea False Porque estamos modificando
            _isNew = false;
            //Habilite el GroupBox para escribir en los atributos (Textbox,Checkbox)
            groupBoxUsuario.Enabled = true;
        }

        private void usuarioDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == usuarioDataGridView.Columns["BtnImageEditar"].Index)
            {
                // Variable Global _isNew sea False Porque estamos modificando
                _isNew = false;
                //Habilite el GroupBox para escribir en los atributos (Textbox,Checkbox)
                groupBoxUsuario.Enabled = true;
            }
            if (e.ColumnIndex == usuarioDataGridView.Columns["BtnImageEliminar"].Index)
            {
                //Recuperar todo lo seleccionado del Usuario en el DataGridView
                var user = (Usuario)usuarioBindingSource.Current;
                //Mensaje 
                DialogResult dlr = MessageBox.Show("Estas Seguro de Eliminar?",
                    "Restaurante",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);
                //Si yo apreto Ok
                if (dlr == DialogResult.OK)
                {
                    _usuarioController.Delete(user);
                }
                //Actualice el DataGridView 
                usuarioBindingSource.DataSource = _usuarioController.GetAll();
            }
        }
    }
}
