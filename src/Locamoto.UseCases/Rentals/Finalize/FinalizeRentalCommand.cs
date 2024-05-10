using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locamoto.UseCases.Core;

namespace Locamoto.UseCases.Rentals.Finalize
{
    public record FinalizeRentalCommand(string Plate, DateOnly EndDate): CommandRequest<FinalizeRentalCommandResponse>
    {
        public override bool IsValid()
        {
            this.ValidateFieldlNull(Plate, "Plate is required.");
            
            if (EndDate < DateOnly.FromDateTime(DateTime.Today))
                AddError("Delivery date must be greater than or equal to today.");

            return base.IsValid();
        }
    }
}