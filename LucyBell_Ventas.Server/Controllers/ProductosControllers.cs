using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LucyBell_Ventas.BD.Data;
using LucyBell_Ventas.BD.Data.Entity;

namespace LucyBell_Ventas.Server.Controllers
{
    [ApiController]
    [Route("Api/Productos")]
    public class ProductosControllers : ControllerBase
    {
        private readonly Context context;

        public ProductosControllers(Context context)
        {
            this.context = context;
        }
        [HttpGet]

        public async Task<ActionResult<List<Producto>>> Get()
        {
            return await context.productos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Producto entidad)
        {
            try
            {
                context.productos.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Producto entidad)
        {

            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos.");
            }

            var verif = await context.productos.Where(e => e.Id == id).FirstOrDefaultAsync();

            if (verif == null)
            {
                return NotFound("No existe la obra buscada.");
            }

            verif.Nombre = entidad.Nombre;
            verif.Precio = entidad.Precio;
            verif.Stock = entidad.Stock;

            try
            {
                context.productos.Update(verif);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
