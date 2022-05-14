using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RevolutionGym.Data.BaseRepository
{
    public interface IEntityBaseRepository<G> where G : class, IEntityBase, new()
    {
        Task<IEnumerable<G>> GetAllAsync();

        Task<IEnumerable<G>> GetAllAsync(params Expression<Func<G, object>>[] includeProperties);

        Task<G> GetByIdAsync(int id);

        Task AddAsync(G entity);

        Task UpdateAsync(int id, G entity);

        Task DeleteAsync(int id);
    }
}
