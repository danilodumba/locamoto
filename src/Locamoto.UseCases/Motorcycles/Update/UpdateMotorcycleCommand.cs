using Locamoto.UseCases.Core;

namespace Locamoto.UseCases.Motorcycles.Update;

public record UpdateMotorcycleCommand(Guid MotorcycleID, string Plate): CommandRequest<UpdateMotorcycleCommandResponse>
{
    public override bool IsValid()
    {
        this.ValidateFieldlNull(MotorcycleID, "The field MotorcycleID is required");
        this.ValidateFieldlNull(Plate, "The field Plate is required");

        return base.IsValid();
    }
}
