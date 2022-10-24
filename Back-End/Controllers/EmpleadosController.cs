using Microsoft.AspNetCore.Mvc;
using ApiEmpleados.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ApiEmpleados.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private Conexion dbConexion;
        public EmpleadosController()
        {
            dbConexion = Conectar.Create();
        }


        [HttpGet]
        public ActionResult<List<Empleado>> Get()
        {
            return Ok(dbConexion.Empleados.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {

            var empleados = await dbConexion.Empleados.FindAsync(id);
            if (empleados != null)
            {
                return Ok(empleados);


            }
            else
            {
                return NotFound();
            }

        }
        [HttpPost]
        public async Task<ActionResult> Post( Empleado empleados)
        {

            if (ModelState.IsValid)
            {

                dbConexion.Empleados.Add(empleados);
                await dbConexion.SaveChangesAsync();
                return Ok(empleados);

            }
            else
            {

                return NotFound();

            }

        }
    }
}