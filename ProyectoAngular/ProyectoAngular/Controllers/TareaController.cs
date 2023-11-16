using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//Referencio esto para usar la base de datos
using Microsoft.EntityFrameworkCore;
using ProyectoAngular.Models;

namespace ProyectoAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        //Creo un atributo que es solo lectura, de tipo DBangularContext (es la referencia de la
        //base de datos que me creo Entity)
        private readonly DbangularContext baseDatos;

        //recibo la base de datos por parametro en el constructor de la clase
        public TareaController(DbangularContext baseDatos)
        {
            this.baseDatos = baseDatos;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var listaTareas= await baseDatos.Tareas.ToListAsync();

            return Ok(listaTareas);
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Tarea request)
        {
            await baseDatos.Tareas.AddAsync(request);
            await baseDatos.SaveChangesAsync();

            return Ok(request);
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var tareaEliminar= await baseDatos.Tareas.FindAsync(id);

            if (tareaEliminar == null)
                return BadRequest("No se puedo eliminar la tarea");

            baseDatos.Tareas.Remove(tareaEliminar);
            await baseDatos.SaveChangesAsync();

            return Ok();
        }

    }
}
