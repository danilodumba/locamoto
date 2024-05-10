using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locamoto.UseCases.Core;

namespace Locamoto.UseCases.Rentals.Create
{
    public record CreateRentCommand(Guid DeliverymanID, Guid PlanID): CommandRequest<CreateRentCommandResponse>
    {
        public override bool IsValid()
        {
            this.ValidateFieldlNull(DeliverymanID, "Deliveryman is required.");
            this.ValidateFieldlNull(PlanID, "Plan is required.");

            return base.IsValid();
        }
    }
}