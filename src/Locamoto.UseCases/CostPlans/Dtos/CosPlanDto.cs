using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locamoto.UseCases.CostPlans.Dtos;
public record CosPlanDto
{
   public Guid Id { get; set; }
   public string? Description { get; set; }
}
