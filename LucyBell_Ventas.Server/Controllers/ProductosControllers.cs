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
			return await repositorio.Select();
		}

		[HttpPost]
        public async Task<ActionResult<int>> Post(CrearProductoDTO entidadDTO)
        {
            try
            {
                Producto entidad = mapper.Map<Producto>(entidadDTO);

                return await repositorio.Insert(entidad);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
