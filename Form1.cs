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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bt_aceptar_Click(object sender, EventArgs e)
        {

            UsuarioDA usuarioDA = new UsuarioDA();
            Usuario usuario = new Usuario();

            usuario = usuarioDA.Login(textBox1.Text, textBox2.Text);

            if (usuario == null)
            {
                MessageBox.Show("Datos erroneos");

            }
            else
            {
                MessageBox.Show("Login Exitoso");
                FrmProductos frmUsuarios = new FrmProductos();
                frmUsuarios.Show();
                this.Hide();

            }





        }
    }
}
