using Capa_dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Presentacion_FORM
{
    public partial class Form1 : Form
    {
        CN_Productos objetoCN = new CN_Productos();
        private string idProducto = null;
        private bool Editar = false; 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }

        private void MostrarProductos()
        {
            CN_Productos objeto = new CN_Productos();
            DatosDataGridView.DataSource = objeto.MostrarProd();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            // INSERTAR 
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarProd(NombreTextBox.Text, DescripcionTextBox.Text, MarcaTextBox.Text, PrecioTextBox.Text, StockTextBox.Text);
                    MessageBox.Show("Se insertó correctamente");
                    MostrarProductos();
                    LimpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos por: " +ex);
                }
            }

            //EDITAR
            if (Editar==true)
            {
                try
                {
                    objetoCN.EditarProd(NombreTextBox.Text, DescripcionTextBox.Text, MarcaTextBox.Text, PrecioTextBox.Text, StockTextBox.Text, idProducto);
                    MessageBox.Show("Se editó correctamente");
                    MostrarProductos();
                    LimpiarForm();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar los datos por: " + ex);
                }
            }

        }

        private void EditarButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                Editar = true;
                NombreTextBox.Text = DatosDataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
                MarcaTextBox.Text = DatosDataGridView.CurrentRow.Cells["Marca"].Value.ToString();
                DescripcionTextBox.Text = DatosDataGridView.CurrentRow.Cells["Descripcion"].Value.ToString();
                PrecioTextBox.Text = DatosDataGridView.CurrentRow.Cells["Precio"].Value.ToString();
                StockTextBox.Text = DatosDataGridView.CurrentRow.Cells["Stock"].Value.ToString();
                idProducto = DatosDataGridView.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void LimpiarForm()
        {
            DescripcionTextBox.Clear();
            MarcaTextBox.Text = "";
            PrecioTextBox.Clear();
            StockTextBox.Clear();
            NombreTextBox.Clear();
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                idProducto = DatosDataGridView.CurrentRow.Cells["Id"].Value.ToString();
                objetoCN.EliminarProd(idProducto);
                MessageBox.Show("Eliminado correctamente");
                MostrarProductos();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void DatosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
