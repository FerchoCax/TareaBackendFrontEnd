namespace ApiEmpleados.Modelos
#nullable disable
{
    public partial class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
    }
}
