using LucyBell_Ventas.BD.Data;

namespace LucyBell_Ventas.Server.Repositorio
{
    public interface IRepositorio<E> where E : class, IEntityBase
    {
		Task<List<E>> Select();
        Task<E> SelectById(int id);
        Task<bool> Existe(int id);
        Task<int> Insert(E entidad);
        Task<bool> Update(int id, E entidad);
        Task<bool> Delete(int id);
    }
}