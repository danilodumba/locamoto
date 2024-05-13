using System.Collections.ObjectModel;
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
    public virtual IReadOnlyCollection<Rent> Rents { get; private set; } = new Collection<Rent>();
    public virtual IReadOnlyCollection<Order> Orders { get; private set; } = new Collection<Order>();


    public void SetCnh(CnhCard cnh)
    {
        this.Cnh = cnh;
        this.Validate();
    }
    public override void Validate()
    {
        this.Name.NotNull("The field Name is required.");
        this.Cnh.NotValid("The CNH is not valid.");
        this.Cnpj.NotValid("The CNPJ is not valid");
    }
}
