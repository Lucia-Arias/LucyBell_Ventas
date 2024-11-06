using AutoMapper;
using LucyBell_Ventas.BD.Data.Entity;
using LucyBell_Ventas.Server.Repositorio;
using LucyBell_Ventas.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace LucyBell_Ventas.Server.Controllers
{
    [ApiController]
    [Route("api/Categorias")]
    public class CategoriasControllers : ControllerBase
    {
        private readonly ICategoriaRepositorio repositorio;
        private readonly IMapper mapper;

        public CategoriasControllers(ICategoriaRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        // Método para obtener todos los productos
        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Get()
        {
            return await repositorio.Select();
        }

        // Método para agregar un nuevo producto
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearCategoriaDTO entidadDTO)
        {
            try
            {
                Categoria entidad = mapper.Map<Categoria>(entidadDTO);

                return await repositorio.Insert(entidad);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Categoria entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos Incorrectos");
            }
            var a = await repositorio.SelectById(id);

            if (a == null)
            {
                return NotFound("No existe la categoria.");
            }

            a.Nombre_Cat = entidad.Nombre_Cat;

            try
            {
                await repositorio.Update(id, a);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await repositorio.Existe(id);
            if (!existe)
            {
                return NotFound($"La categoria {id} no existe.");
            }
            if (await repositorio.Delete(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
