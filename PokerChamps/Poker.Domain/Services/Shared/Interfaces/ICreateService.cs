using Poker.Domain.Entities.Base;

namespace Poker.Domain.Services.Shared.Interfaces;

public interface ICreateService<TEntity> where TEntity : Entity 
{
    Task<(bool success, string reason)> Create(TEntity entity);
    
    Task<(bool success, string reason)> Update(TEntity entity);
}