using System.Linq;

namespace sportlife.Services
{
    public interface IStaticticsService
    {
        IQueryable GetByType();
    }
}