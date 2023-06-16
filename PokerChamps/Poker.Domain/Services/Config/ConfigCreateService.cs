using Poker.Domain.Entities.Config;
using Poker.Domain.Services.Config.Interfaces;
using Poker.Domain.Services.Shared.Interfaces;

namespace Poker.Domain.Services.Config;

// public class ConfigCreateService : IConfiCreateService
// {
//     private readonly ICreateService<Configs> _createService;
//
//     public ConfigCreateService(ICreateService<Configs> createService)
//     {
//         _createService = createService;
//     }
//     
//     public async Task<(bool success, string reason)> Create(Configs entity)
//     {
//         return await _createService.Create(entity);
//     }
//
//     public async Task<(bool success, string reason)> Update(Configs entity)
//     {
//         return await _createService.Update(entity);
//     }
// }