using Poker.Domain.Adapters.Repositories;
using Poker.Domain.Entities.Base;
using Poker.Domain.Services.Config.Interfaces;
using Poker.Domain.Services.Shared.Interfaces;

namespace Poker.Domain.Services.Shared;

public class CreateService<T> : ICreateService<T> where T : Entity
{
    private readonly IRepository<T> _repository;

    public CreateService(IRepository<T> repository)
    {
        _repository = repository;
    }

    public virtual async Task<(bool success, string reason)> Create(T entity)
    {
        await _repository.InsertOneAsync(entity);
        return (true, null);
    }

    public virtual async Task<(bool success, string reason)> Update(T entity)
    {
        await _repository.UpdateAsync(entity);
        return (true, null);
    }
}