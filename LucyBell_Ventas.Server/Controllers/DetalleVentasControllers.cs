using AutoMapper;
using LucyBell_Ventas.BD.Data.Entity;
using LucyBell_Ventas.Server.Repositorio;
using LucyBell_Ventas.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace LucyBell_Ventas.Server.Controllers
{
    [ApiController]
    [Route("api/DetalleVenta")]
    public class DetalleVentasControllers : ControllerBase
    {
        private readonly IDetalleVentaRepositorio repositorio;
        private readonly IMapper mapper;

        public DetalleVentasControllers(IDetalleVentaRepositorio repositorio,
                                  IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<DetalleVenta>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearDetalleVentaDTO entidadDTO)
        {
            try
            {
                DetalleVenta entidad = mapper.Map<DetalleVenta>(entidadDTO);

                return await repositorio.Insert(entidad);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] DetalleVenta entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos Incorrectos");
            }
            var a = await repositorio.SelectById(id);

            if (a == null)
            {
                return NotFound("No existe el detalle de venta.");
            }

            a.Cantidad = entidad.Cantidad;

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
                return NotFound($"El detalle de venta {id} no existe.");
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
