using Locamoto.Domain.ValueObjects;
using Locamoto.UseCases.Core;

namespace Locamoto.UseCases.DeliveryDrivers.Create;

public record CreateDeliverymanCommand(string Name, CNPJ Cnpj, DateOnly BirthDate, CnhCard Cnh): CommandRequest<CreateDeliverymanCommandResponse>
{
    public override bool IsValid()
    {
        this.ValidateFieldlNull(Name, "The field Name is required");

        if (!Cnpj.IsValid()) this.AddError("The field CNPJ is invalid");
        if (!Cnh.IsValid()) this.AddError("The field CNH is invalid");

        return base.IsValid();
    }
}
