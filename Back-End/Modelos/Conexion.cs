using Microsoft.EntityFrameworkCore;

namespace ApiEmpleados.Modelos
{

    public class Conexion : DbContext
    {

        public Conexion(DbContextOptions<Conexion> options) : base(options) { }
        public DbSet<Empleado> Empleados { get; set; }

    }
    class Conectar
    {

        private const string cadenaConexion = "server=localhost;port=3306;database=db_empresa;userid=usr_empresa;pwd=Empres@123";
        public static Conexion Create()
        {

            var constructor = new DbContextOptionsBuilder<Conexion>();
            constructor.UseMySql("server=localhost;port=3306;database=db_empresa;userid=usr_empresa;pwd=Empres@123");
            var cn = new Conexion(constructor.Options);
            return cn;

        }

    }


}