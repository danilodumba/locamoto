using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locamoto.Domain.Core;

namespace Locamoto.Domain.Entities;

public class CostPlan: EntityRoot
{
    public CostPlan(int startDay, int endDay, decimal costPerDay, decimal percentageFine, decimal additionalCostPerDay, string description = "")
    {
        StartDay = startDay;
        EndDay = endDay;
        CostPerDay = costPerDay;
        PercentageFine = percentageFine;
        AdditionalCostPerDay = additionalCostPerDay;
        Description = description;
    }

    public int StartDay { get; private set; }
    public int EndDay { get; private set; }
    public decimal CostPerDay { get; private set; }
    public decimal AdditionalCostPerDay { get; private set; }
    public decimal PercentageFine { get; private set; }
    public string Description { get; private set; }

    public override void Validate()
    {
    }
}
