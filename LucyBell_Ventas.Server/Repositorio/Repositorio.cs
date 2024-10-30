using AutoMapper;
using LucyBell_Ventas.BD.Data;
using LucyBell_Ventas.BD.Data.Entity;
using LucyBell_Ventas.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LucyBell_Ventas.Server.Repositorio
{
    public class Repositorio<E> : IRepositorio<E> where E : class, IEntityBase
    {
        private readonly Context context;

        public Repositorio(Context context)
        {
            this.context = context;
        }

        public async Task<int> Insert(E entidad)
        {
            try
            {
                await context.Set<E>().AddAsync(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
