namespace ExamenAngieeRosales.Entidades
{
    public class Producto
    {
        public string Codigo { get; set; }  
        public string Descripcion { get; set; }   
         
        public string Precio { get; set; }  
         public int Existencia { get; set; }

        public Producto(string codigo, string descripcion, string precio, int existencia)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Precio = precio;
            Existencia = existencia;
        }

        public Producto()
        {
        }
    }
}
