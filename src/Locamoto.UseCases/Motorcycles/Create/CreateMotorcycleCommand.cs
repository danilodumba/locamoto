using Locamoto.UseCases.Core;

namespace Locamoto.UseCases.Motorcycles.Create;

public record CreateMotorcycleCommand(int Year, string Model, string Plate): CommandRequest<CreateMotorcycleCommandResponse>
{
    public override bool IsValid()
    {
        this.ValidateFieldlNull(Model, "The field Model is required");
        this.ValidateFieldlNull(Plate, "The field Plate is required");

        return base.IsValid();
    }
}
