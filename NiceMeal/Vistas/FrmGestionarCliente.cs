using NiceMeal.Controladores;
using NiceMeal.Models;
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
    public partial class FrmGestionarCliente : Form
    {
        public FrmGestionarCliente()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        public void Guardar()
        {
            var client = (Cliente)clienteBindingSource.Current;

            if (_isNew == true)
            {
                _clienteController.Create(client);
            }
            else
            {
                _clienteController.Update(client);
            }

            //Desabilite los atributos (Textbox,Checkbox) para agregar o modificar un Cliente
            groupBoxCliente.Enabled = false;
            //Actualice el DataGridView 
            clienteBindingSource.DataSource = _clienteController.GetAll();
        }

        private void FrmGestionarCliente_Load(object sender, EventArgs e)
        {
            //Cuando Cargue la pantalla muestre en el DataGridView todos los clientes de la BBDD
            clienteBindingSource.DataSource = _clienteController.GetAll();
        }
        ClienteController _clienteController = new ClienteController();
        //Para saber si el Cliente es nuevo o estamos modificando al Cliente
        bool _isNew = true;

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Desabilite los atributos (Textbox,Checkbox) para agregar o modificar un Cliente
            groupBoxCliente.Enabled = false;
            //Elimina todo lo que se escribio en los atributos  (Textbox,Checkbox) del Cliente
            clienteBindingSource.CancelEdit();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string par = txtBuscar.Text;
            //Que en el DataGridView Muestre todos los clientes que cumplan con el paramatro "par"
            clienteBindingSource.DataSource = _clienteController.Search(par);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //Variable Global _isNew sea True
            _isNew = true;
            //Habilite el GroupBox para escribir en los atributos (Textbox,Checkbox)
            groupBoxCliente.Enabled = true;
            //Borre todo lo que antes estaba escrito para escribir los nuevos datos en los atributos (Textbox,Checkbox)
            clienteBindingSource.AddNew();
        }

        private void clienteDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == clienteDataGridView.Columns["BtnImageEditar"].Index)
            {
                // Variable Global _isNew sea False Porque estamos modificando
                _isNew = false;
                //Habilite el GroupBox para escribir en los atributos (Textbox,Checkbox)
                groupBoxCliente.Enabled = true;
            }
            if (e.ColumnIndex == clienteDataGridView.Columns["BtnImageEliminar"].Index)
            {
                //Recuperar todo lo seleccionado del Usuario en el DataGridView
                var client = (Cliente)clienteBindingSource.Current;
                //Mensaje 
                DialogResult dlr = MessageBox.Show("Estas Seguro de Eliminar?",
                    "Restaurante",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);
                //Si yo apreto Ok
                if (dlr == DialogResult.OK)
                {
                    _clienteController.Delete(client);
                }
                //Actualice el DataGridView 
                clienteBindingSource.DataSource = _clienteController.GetAll();
            }
        }
    }
}
