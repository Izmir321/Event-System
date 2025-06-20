using Persistence.Entities;
using Persistence.Models;
using System.Linq.Expressions;

namespace Persistence.Repositories;

public interface IEventRepository
{
    Task<RepositoryResult<IEnumerable<EventEntity>>> GetAllAsync();
    Task<RepositoryResult<EventEntity?>> GetAsync(Expression<Func<EventEntity, bool>> expression);
    Task<RepositoryResult> AddAsync(EventEntity entity);
}


/* 
 * using Persistence.Entities;
using Persistence.Models;

namespace Persistence.Repositories;

public interface IEventRepository1 : IBaseRepository<EventEntity>
{
    Task<RepositoryResult> AddAsync(EventEntity entity);
}
*/

