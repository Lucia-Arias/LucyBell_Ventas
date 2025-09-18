using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LucyBell_Ventas.BD.Data;
using LucyBell_Ventas.BD.Data.Entity;
using LucyBell_Ventas.Shared.DTO;
using AutoMapper;
using LucyBell_Ventas.Server.Repositorio;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.OutputCaching;

namespace LucyBell_Ventas.Server.Controllers
{
    [ApiController]
    [Route("Api/Productos")]
    public class ProductosControllers : ControllerBase
    {
        private readonly IProductoRepositorio repositorio;
        private readonly IMapper mapper;
        private readonly IOutputCacheStore outputCacheStore;

        private const string cacheKey = "Productos";

        public ProductosControllers(IProductoRepositorio repositorio,IMapper mapper, IOutputCacheStore outputCacheStore)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
            this.outputCacheStore = outputCacheStore;
        }

		[HttpGet]
  [OutputCache(Tags = [cacheKey])]
		public async Task<ActionResult<List<Producto>>> Get()
		{
            var productos = await repositorio.Select();
            if (productos == null || !productos.Any())
            {
                return NotFound("No se encontraron productos.");
            }
            return Ok(productos);
        }

		[HttpPost]
        public async Task<ActionResult<Producto>> Post(CrearProductoDTO entidadDTO)
        {
            try
            {
                Producto entidad = mapper.Map<Producto>(entidadDTO);
                var nuevoId = await repositorio.Insert(entidad);

                await outputCacheStore.EvictByTagAsync(cacheKey, default);

                return CreatedAtAction(nameof(Get), new { id = nuevoId }, entidad);
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
                return BadRequest("Datos Incorrectos");
            }
            var a = await repositorio.SelectById(id);

            if (a == null)
            {
                return NotFound("No existe el producto.");
            }

            a.Nombre = entidad.Nombre;
            a.Stock = entidad.Stock;
            a.Precio = entidad.Precio;

            try
            {
                await repositorio.Update(id, a);
                await outputCacheStore.EvictByTagAsync(cacheKey, default);
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
                return NotFound($"El producto {id} no existe.");
            }
            if (await repositorio.Delete(id))
            {
                await outputCacheStore.EvictByTagAsync(cacheKey, default);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
