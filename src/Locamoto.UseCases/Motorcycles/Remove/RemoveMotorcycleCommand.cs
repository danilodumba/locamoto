using Locamoto.UseCases.Core;

namespace Locamoto.UseCases.Motorcycles.Remove;

public record RemoveMotorcycleCommand(Guid MotorcycleID): CommandRequest<RemoveMotorcycleCommandResponse>
{
    public override bool IsValid()
    {
        this.ValidateFieldlNull(MotorcycleID, "The field MotorcycleID is required");

        return base.IsValid();
    }
}
