using AutoMapper;
using LucyBell_Ventas.BD.Data.Entity;
using LucyBell_Ventas.Server.Repositorio;
using LucyBell_Ventas.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace LucyBell_Ventas.Server.Controllers
{
    [ApiController]
    [Route("api/Ventas")]
    public class VentasControllers : ControllerBase
    {
        private readonly IVentaRepositorio repositorio;
        private readonly IMapper mapper;

        public VentasControllers(IVentaRepositorio repositorio,
                                  IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]    //api/Titulos
        public async Task<ActionResult<List<Venta>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearVentaDTO entidadDTO)
        {
            try
            {
                Venta entidad = mapper.Map<Venta>(entidadDTO);

                return await repositorio.Insert(entidad);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Venta entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos Incorrectos");
            }
            var a = await repositorio.SelectById(id);

            if (a == null)
            {
                return NotFound("No existe la venta.");
            }

            a.Fecha = entidad.Fecha;

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
                return NotFound($"La venta {id} no existe.");
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
