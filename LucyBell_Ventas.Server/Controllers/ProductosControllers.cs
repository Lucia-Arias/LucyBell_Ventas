using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LucyBell_Ventas.BD.Data;
using LucyBell_Ventas.BD.Data.Entity;
using LucyBell_Ventas.Shared.DTO;
using AutoMapper;
using LucyBell_Ventas.Server.Repositorio;

namespace LucyBell_Ventas.Server.Controllers
{
    [ApiController]
    [Route("Api/Productos")]
    public class ProductosControllers : ControllerBase
    {
        private readonly IProductoRepositorio repositorio;
        private readonly IMapper mapper;

        public ProductosControllers(IProductoRepositorio repositorio,IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

		[HttpGet]
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
                return CreatedAtAction(nameof(Get), new { id = nuevoId }, entidad);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
