using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenAngieeRosales.Entidades
{
    public class Pedidos
    {
        public string Nombre { get; set; }  

        public string Descripcion { get; set; } 

        public decimal precio { get; set; }

        public Pedidos(string nombre, string descripcion, decimal precio)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            this.precio = precio;

        }
        public Pedidos()
        {

        }
    }
}
