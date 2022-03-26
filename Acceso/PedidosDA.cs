using ExamenAngieeRosales.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenAngieeRosales.Acceso
{
    public  class PedidosDA
    {
       
        readonly string cadena = "Server=localhost; Port=3306; Database=programacion; Uid=root;";

        MySqlConnection conn;
        MySqlCommand cmd;
        public DataTable ListarPedidos()
        {
            DataTable lista = new DataTable();

            try
            {
                string sql = "SELECT * FROM pedidos;";
                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                lista.Load(reader);
                reader.Close();
                conn.Close();

            }
            catch (Exception ex)
            {


            }
            return lista;


        }

        public bool InsertarPedidos(Pedidos pedidos)
        {
            bool inserto = false;
            try
            {

                string sql = "INSERT INTO pedidos VALUES (@Nombre,@Descripcion,@Precio);";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Nombre", pedidos.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion",pedidos.Descripcion);
                cmd.Parameters.AddWithValue("@Precio", pedidos.precio);
    

                cmd.ExecuteNonQuery();
                inserto = true;
                conn.Close();

            }
            catch (Exception)
            {

            }

            return inserto;

        }
        public bool EliminarPedido(string nombre)
        {
            bool elimino = false;
            try
            {

                string sql = "DELETE FROM pedido WHERE Codigo = @Nombre;";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Nombre", nombre);



                cmd.ExecuteNonQuery();
                elimino = true;
                conn.Close();

            }
            catch (Exception ex)
            {

            }
            return elimino;
        }


    }
}
