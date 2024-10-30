using LucyBell_Ventas.BD.Data;

namespace LucyBell_Ventas.Server.Repositorio
{
    public interface IRepositorio<E> where E : class, IEntityBase
    {
        Task<int> Insert(E entidad);
    }
}