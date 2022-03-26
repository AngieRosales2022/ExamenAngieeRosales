using ExamenAngieeRosales.Acceso;
using ExamenAngieeRosales.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenAngieeRosales
{
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();
        }
        string operacion = string.Empty;
        ProductoDA productoDA = new ProductoDA();
       
        private void FrmProductos_Load(object sender, EventArgs e)
        {

            ListarProductos();
        }

        private void bt_modificar_Click(object sender, EventArgs e)
        {
             operacion = "Modificar";
        
            Producto producto = new Producto();
            bool inserto = productoDA.InsertarProducto(producto);
            if (dataGridView1.SelectedRows.Count > 0)
            {

                cod_txt.Text = dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString();
                cod_txt.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                cod_txt.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                cod_txt.Text = dataGridView1.CurrentRow.Cells["Existencia"].Value.ToString();


                if (operacion == "Modificar")
                {
                    bool modifico = productoDA.ModificarProducto(producto);


                    LimpiarControles();

                    ListarProductos();
                    MessageBox.Show("Producto Modificado");

                }
           



            }


        }

        private void bt_guardar_Click(object sender, EventArgs e)
        {

                operacion = "Nuevo";

            if (string.IsNullOrEmpty(cod_txt.Text))
                {
                    MessageBox.Show("Debe Ingresar codigo");
                    cod_txt.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(desc_txt.Text))
                {
                    MessageBox.Show("Debe Ingresar Descripcion");
                    desc_txt.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(precio_txt.Text))
                {
                    MessageBox.Show("Debe Ingresar precio");
                    precio_txt.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(existencia_txt.Text))
                {
                    MessageBox.Show("Debe Ingresar la existencia");
                    existencia_txt.Focus();
                    return;
                }

                Producto producto = new Producto();
                producto.Codigo = cod_txt.Text;
                producto.Descripcion = desc_txt.Text;
                producto.Precio = precio_txt.Text;
                producto.Existencia = Convert.ToInt32(existencia_txt.Text);

            if (operacion == "Nuevo")
            {
                bool inserto = productoDA.InsertarProducto(producto);

                if (inserto)
                {
                    ListarProductos();
                    MessageBox.Show("Producto insertado");
                }
            }


        }
  
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void ListarProductos()
        {
            dataGridView1.DataSource = productoDA.ListarProductos();
        }

        private void bt_nuevi_Click(object sender, EventArgs e)
        {

        }
        private void LimpiarControles()
        {
            cod_txt.Clear();
            desc_txt.Clear();
            precio_txt.Clear();
            existencia_txt.Clear();
            
        }

        private void bt_eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                bool elimino = productoDA.EliminarProducto(dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString());
                MessageBox.Show("Producto eliminado");
                ListarProductos();
                LimpiarControles();
            }
            }

        private void button1_Click(object sender, EventArgs e)
        {

            PedidosCliente frmPedidos = new PedidosCliente();
            frmPedidos.Show();
            this.Hide();

   

        }
    }
}
