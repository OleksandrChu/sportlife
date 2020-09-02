using System.Threading.Tasks;

namespace sportlife.Repositories
{
    public interface IRepository<T>
    {
        Task<T> Create(T model);

        Task<T> Select(int id);

        Task<T> Update(T model);

    }
}