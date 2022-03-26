using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenAngieeRosales.Entidades;
using MySql.Data.MySqlClient;
namespace ExamenAngieeRosales.Acceso
{
    public  class UsuarioDA
    {
        readonly string cadena = "Server=localhost; Port=3306; Database=programacion; Uid=root;";

        MySqlConnection conn;
        MySqlCommand cmd;

        public Usuario Login(string codigo, string clave)
        {
            Usuario user = null;

            try
            {
                string sql = "SELECT * FROM usuario WHERE codigo= @Codigo and Clave = @Clave;";
                conn = new MySqlConnection(cadena);
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.Parameters.AddWithValue("@Clave", clave);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    user = new Usuario();
                    user.Codigo = reader[0].ToString();
                    user.Clave = reader[1].ToString();
                }

                reader.Close();
                conn.Close();



            }
            catch (Exception ex)
            {
                
            }
            return user;
        }
        public DataTable ListarUsuarios()
        {
            DataTable listarUsuarioDT = new DataTable();
            try
            {
                string sql = "SELECT * FROM usuario;";
                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                listarUsuarioDT.Load(reader);


            }
            catch (Exception ex)
            {


            }
            return listarUsuarioDT;

        }
    }
}
