using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Poker.Api.v1.Dtos.Shared;

public class PlayersComplianceAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var values = value as IList;
        
        if (values == null || values.Count < 2)
        {
            return new ValidationResult("É necessário selecionar ao menos 2 jogadores para a partida!");
        }
        return ValidationResult.Success;
    }
}