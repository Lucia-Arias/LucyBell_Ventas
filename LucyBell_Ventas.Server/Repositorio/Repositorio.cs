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

        public async Task<bool> Existe(int id)
        {
            var existe = await context.Set<E>()
                             .AnyAsync(x => x.Id == id);
            return existe;
        }

        public async Task<List<E>> Select()
		{
			return await context.Set<E>().ToListAsync();
		}

        public async Task<E> SelectById(int id)
        {
            E? a = await context.Set<E>()
                .AsNoTracking()
                .FirstOrDefaultAsync(
                x => x.Id == id);
            return a;
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

        public async Task<bool> Update(int id, E entidad)
        {
            if (id != entidad.Id)
            {
                return false;
            }

            var a = await SelectById(id);

            if (a == null)
            {
                return false;
            }

            try
            {
                context.Set<E>().Update(entidad);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var a = await SelectById(id);

            if (a == null)
            {
                return false;
            }

            context.Set<E>().Remove(a);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
