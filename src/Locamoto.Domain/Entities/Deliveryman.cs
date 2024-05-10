using Locamoto.Domain.Core;
using Locamoto.Domain.Validations;
using Locamoto.Domain.ValueObjects;

namespace Locamoto.Domain.Entities;

public class Deliveryman : EntityRoot
{
    protected Deliveryman() {}
    
    public Deliveryman(string name, CNPJ cnpj, DateOnly birthDate, CnhCard cnh)
    {
        Name = name;
        Cnpj = cnpj;
        BirthDate = birthDate;
        Cnh = cnh;

        this.Validate();
    }

    public string Name { get; private set; } = "";
    public CNPJ Cnpj { get; private set; }
    public DateOnly BirthDate { get; private set; }
    public CnhCard Cnh { get; private set; }

    public override void Validate()
    {
        this.Name.NotNull("The field Name is required.");
        this.Cnh.NotValid("The CNH is not valid.");
        this.Cnpj.NotValid("The CNPJ is not valid");
    }
}
