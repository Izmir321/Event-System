using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Entities;
using Persistence.Models;
using System.Linq.Expressions;

namespace Persistence.Repositories;

public class EventRepository : BaseRepository<EventEntity>, IEventRepository
{
    public EventRepository(DataContext context) : base(context)
    {
    }

    public async Task<RepositoryResult<IEnumerable<EventEntity>>> GetAllAsync()
    {
        try
        {
            var entities = await _table.Include(x => x.Packages).ToListAsync();
            return new RepositoryResult<IEnumerable<EventEntity>> { Success = true, Result = entities };
        }
        catch (Exception ex)
        {
            return new RepositoryResult<IEnumerable<EventEntity>>
            {
                Success = false,
                Error = ex.Message,
            };
        }
    }

    public async Task<RepositoryResult<EventEntity?>> GetAsync(Expression<Func<EventEntity, bool>> expression)
    {
        try
        {
            var entity = await _table.Include(x => x.Packages)
                                     .FirstOrDefaultAsync(expression)
                          ?? throw new Exception("Not Found.");

            return new RepositoryResult<EventEntity?> { Success = true, Result = entity };
        }
        catch (Exception ex)
        {
            return new RepositoryResult<EventEntity?>
            {
                Success = false,
                Error = ex.Message,
            };
        }
    }

    public async Task<RepositoryResult> AddAsync(EventEntity entity)
    {
        try
        {
            _table.Add(entity);
            await _context.SaveChangesAsync();

            return new RepositoryResult { Success = true };
        }
        catch (Exception ex)
        {
            return new RepositoryResult
            {
                Success = false,
                Error = ex.Message
            };
        }
    }
}














/*
 * using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Entities;
using Persistence.Models;
using System.Linq.Expressions;

namespace Persistence.Repositories;

public interface IEventRepository1
{
    Task<RepositoryResult<IEnumerable<EventEntity>>> GetAllAsync(EventEntity entity);
    Task<RepositoryResult<EventEntity?>> GetAsync(Expression<Func<EventEntity, bool>> expression);
}

public class EventRepository(DataContext context) : BaseRepository<EventEntity>(context), IEventRepository1, IEventRepository1
{
    public override async Task<RepositoryResult<IEnumerable<EventEntity>>> GetAllAsync()
    {
        try
        {
            var entities = await _table.Include(x => x.Packages).ToListAsync();
            return new RepositoryResult<IEnumerable<EventEntity>> { Success = true, Result = entities };
        }
        catch (Exception ex)
        {
            return new RepositoryResult<IEnumerable<EventEntity>>
            {
                Success = false,
                Error = ex.Message,
            };
        }
    }

    public override async Task<RepositoryResult<EventEntity?>> GetAsync(Expression<Func<EventEntity, bool>> expression)
    {
        try
        {
            var entity = await _table.Include(x => x.Packages).FirstOrDefaultAsync(expression) ?? throw new Exception("Not Found.");
            return new RepositoryResult<EventEntity?> { Success = true, Result = entity };
        }
        catch (Exception ex)
        {
            return new RepositoryResult<EventEntity?>
            {
                Success = false,
                Error = ex.Message,
            };
        }
    }
}

 */
