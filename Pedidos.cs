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
    public partial class PedidosCliente : Form
    {
        public PedidosCliente()
        {
            InitializeComponent();
        }

        string operacion = string.Empty;
        PedidosDA PedidosDA = new PedidosDA();


        private void button1_Click(object sender, EventArgs e)
        {


            operacion = "Nuevo";
            Pedidos pedido = new Pedidos();
           
      
            pedido.Nombre =textBox1.Text;
            pedido.Descripcion =textBox2.Text;
            pedido.precio = Convert.ToDecimal(textBox3.Text);

            bool inserto = PedidosDA.InsertarPedidos(pedido);
            if (operacion == "Nuevo")
            {

                if (inserto)
                {
                   ListarPedidos();
                    MessageBox.Show("Pedido insertado");

                }
            }
          

        }
        private void ListarPedidos()
        {
            dataGridView1.DataSource = PedidosDA.ListarPedidos();
        }

        private void PedidosCliente_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = PedidosDA.ListarPedidos();
        }

        private void bt_nuevi_Click(object sender, EventArgs e)
        {
          
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
              
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                bool elimino = PedidosDA.EliminarPedido(dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString());
                MessageBox.Show("Pedido eliminado");
                ListarPedidos();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
        }
    }
    }

