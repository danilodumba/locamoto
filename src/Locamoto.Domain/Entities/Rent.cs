using Locamoto.Domain.Core;
using Locamoto.Domain.Exceptions;
using Locamoto.Domain.Validations;

namespace Locamoto.Domain.Entities;

public class Rent: EntityRoot
{
    protected Rent() {}
    public Rent(Motorcycle motorcycle, Deliveryman deliveryman, CostPlan plan)
    {
        Motorcycle = motorcycle;
        Deliveryman = deliveryman;
        Plan = plan;
    

        SetStartDate();
        SetExpectedEndDate(plan.EndDay);
        CalculateExpectedCost();
        SetMotorcycleUnavaliable();

        Validate();
    }

    public DateOnly StartDate { get; private set; }
    public DateOnly CreatedDate { get; private set; } = DateOnly.FromDateTime(DateTime.Now);
    public DateOnly ExpectedEndDate { get; private set; }
    public DateOnly? EndDate { get; private set; }
    public decimal ExpectedCost { get; private set; } = 0;
    public decimal FineCost { get; private set; } = 0;
    public decimal RealCost { get; private set; } = 0;
    public StatusRent Status { get; private set; } = StatusRent.Active;
    public virtual Motorcycle Motorcycle { get; private set; } = null!;
    public virtual CostPlan Plan { get; private set; } = null!;
    public virtual Deliveryman Deliveryman { get; private set; } = null!;

    public override void Validate()
    {
        this.Motorcycle.NotNull("The field Motorcycle is required.");
        this.Plan.NotNull("The field Plan is required.");
        this.Deliveryman.NotNull("The field Deliveryman is required.");

        if (this.Deliveryman.Cnh.Type == ValueObjects.CnhType.B)
            throw new DomainException("Your category does not allow motorcycle rental");
    }

    public void FinalizeRental(DateOnly endDate)
    {
        this.EndDate = endDate;
        CalculateRealCost();
        Status = StatusRent.Finalized;

        var remainingDays = endDate.DayNumber - this.ExpectedEndDate.DayNumber;
        if (remainingDays == 0) return;

        if (remainingDays > 0) 
        {
            CalculateAdditionalCost(remainingDays);
            return; 
        }

       CalculateFineForDays(remainingDays * -1);
    }

    private void CalculateRealCost()
    {
        var remainingDays = this.EndDate?.DayNumber - this.ExpectedEndDate.DayNumber;
        var usedDays = Plan.EndDay + remainingDays;
        this.RealCost = Plan.CostPerDay * usedDays ?? 0;
    }

    public decimal CostTotal()
    {
        return this.RealCost + this.FineCost;
    }

    public int DaysOfRent()
    {
        return this.ExpectedEndDate.DayNumber - this.StartDate.DayNumber;
    }

    private void CalculateFineForDays(int days)
    {
        var cost = this.Plan.CostPerDay * days;
        this.FineCost = cost * (this.Plan.PercentageFine / 100);
    }

    private void CalculateAdditionalCost(int days)
    {
        this.FineCost = this.Plan.AdditionalCostPerDay * days;
    }

    private void SetStartDate()
    {
        this.StartDate = this.CreatedDate.AddDays(1);
    }

    private void SetExpectedEndDate(int numberOfDays)
    {
        if (numberOfDays < 1) throw new DomainException("Number of days cannot be less than one.");

        this.ExpectedEndDate =  this.StartDate.AddDays(numberOfDays);
    }

    private void CalculateExpectedCost()
    {
        var days = this.DaysOfRent();
        this.ExpectedCost = days * this.Plan.CostPerDay;
    }

    private void SetMotorcycleUnavaliable()
    {
        this.Motorcycle.SetUnavailable();
    }
    
}

public enum StatusRent
{
    Active = 1,
    Finalized = 2
}