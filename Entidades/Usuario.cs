using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace ExamenAngieeRosales.Entidades
{
    public class Usuario
    {
        public String Codigo { get; set; }

        public String Clave { get; set; }

        public Usuario(string codigo, string clave)
        {
            Codigo = codigo;
            Clave = clave;
        }

        public Usuario()
        {
        }




    }
}
