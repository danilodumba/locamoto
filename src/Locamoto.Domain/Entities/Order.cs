using Locamoto.Domain.Core;
using Locamoto.Domain.Exceptions;

namespace Locamoto.Domain.Entities;

public class Order: EntityRoot
{
    public Order(decimal cost)
    {
        CreatedAt = DateTime.UtcNow;
        Cost = cost;

        Avaliable();
        Validate();
    }

    public DateTime CreatedAt { get; private set; }    
    public decimal Cost { get; private set; }
    public StatusOrder Status { get; private set; }
    public virtual Deliveryman? Deliveryman {get; private set; }

    public void Accept(Deliveryman deliveryman)
    {
        this.Deliveryman = deliveryman;
        this.Status = StatusOrder.Accept;
    }

    public void Delivered()
    {
        this.Status = StatusOrder.Delivered;
    }

    public void Avaliable()
    {
        this.Status = StatusOrder.Avaliable;
    }

    public override void Validate()
    {
        if (Cost <= 0) throw new DomainException("The cost must be more than zero.");
    }
}

public enum StatusOrder 
{
    Avaliable = 1,
    Accept = 2,
    Delivered = 3
}