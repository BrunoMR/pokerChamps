using System.Linq.Expressions;
using Poker.Domain.Adapters.Repositories;
using Poker.Domain.Entities.Base;
using Poker.Domain.Services.Config.Interfaces;

namespace Poker.Domain.Services.Shared;

public class QueryService<T> : IQueryService<T> where T : Entity
{
    private readonly IRepository<T> _repository;

    public QueryService(IRepository<T> repository)
    {
        _repository = repository;
    }

    public async Task<T> Get(Expression<Func<T, bool>> predicate)
    {
        return await _repository.GetByFilterAsync(predicate);
    }

    public async Task<IEnumerable<T>> GetList(Expression<Func<T, bool>> predicate)
    {
        return await _repository.GetAllByFilterAsync(predicate);
    }
}