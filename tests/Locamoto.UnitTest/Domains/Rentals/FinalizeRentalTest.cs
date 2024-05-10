using Locamoto.Domain.Entities;
using Locamoto.UnitTest.Domains.Deliverymans;
using Locamoto.UnitTest.Domains.Motorcycles;
using Locamoto.UnitTest.Domains.Plans;

namespace Locamoto.UnitTest.Domains.Rentals;
public class FinalizeRentalTest
{
    [Fact]
    public void Must_Finalize_Rental_In_Deadline_PlanSevenDays()
    {
        var plan = PlanMock.GetPlanSevenDays();
        var rent = new Rent(
                MotorcycleMock.GetMotorcycle(), 
                DeliverymanMock.GetDeliveryman(), 
                plan);
        
        var realEndDate = rent.ExpectedEndDate;
        var totalCost = plan.CostPerDay * plan.EndDay;

        rent.FinalizeRental(realEndDate);

        Assert.True(rent.CostTotal() == totalCost, $"The cost of rental invalid. Expected {totalCost}. Real: {rent.CostTotal()}");
    }

    [Fact]
    public void Must_Finalize_Rental_Before_Deadline_PlanSevenDays()
    {
        var planSevenDays = PlanMock.GetPlanSevenDays();
        var rent = new Rent(
                MotorcycleMock.GetMotorcycle(), 
                DeliverymanMock.GetDeliveryman(), 
                planSevenDays);
        
        var endDate = rent.ExpectedEndDate;
        var realEndDate = endDate.AddDays(-3);
        var realCost = planSevenDays.CostPerDay * 4;
        var fineCost = planSevenDays.CostPerDay * 3 * 0.2M;
        var totalCost = realCost + fineCost;

        rent.FinalizeRental(realEndDate);

        Assert.True(rent.CostTotal() == totalCost, $"The cost of rental invalid. Expected {totalCost}. Real: {rent.CostTotal()}");
    }

    [Fact]
    public void Must_Finalize_Rental_After_Deadline_PlanSevenDays()
    {
        var planSevenDays = PlanMock.GetPlanSevenDays();
        var rent = new Rent(
                MotorcycleMock.GetMotorcycle(), 
                DeliverymanMock.GetDeliveryman(), 
                planSevenDays);
        
        var endDate = rent.ExpectedEndDate;
        var realEndDate = endDate.AddDays(10);
        var realCost = planSevenDays.CostPerDay * 17;
        var additionalCost = planSevenDays.AdditionalCostPerDay * 10;
        var totalCost = realCost + additionalCost;

        rent.FinalizeRental(realEndDate);

        Assert.True(rent.CostTotal() == totalCost, $"The cost of rental invalid. Expected {totalCost}. Real: {rent.CostTotal()}");
    }

    [Fact]
    public void Must_Finalize_Rental_In_Deadline_PlanFifteenDays()
    {
        var plan = PlanMock.GetPlanFifteenDays();
        var rent = new Rent(
                MotorcycleMock.GetMotorcycle(), 
                DeliverymanMock.GetDeliveryman(), 
                plan);
        
        var realEndDate = rent.ExpectedEndDate;
        var totalCost = plan.CostPerDay * plan.EndDay;

        rent.FinalizeRental(realEndDate);

        Assert.True(rent.CostTotal() == totalCost, $"The cost of rental invalid. Expected {totalCost}. Real: {rent.CostTotal()}");
    }

    [Fact]
    public void Must_Finalize_Rental_Before_Deadline_PlanFifteenDays()
    {
        var pan = PlanMock.GetPlanFifteenDays();
        var rent = new Rent(
                MotorcycleMock.GetMotorcycle(), 
                DeliverymanMock.GetDeliveryman(), 
                pan);
        
         var endDate = rent.ExpectedEndDate;
        var realEndDate = endDate.AddDays(-5);
        var realCost = pan.CostPerDay * 10;
        var fineCost = pan.CostPerDay * 5 * 0.4M;
        var totalCost = realCost + fineCost;

        rent.FinalizeRental(realEndDate);

        Assert.True(rent.CostTotal() == totalCost, $"The cost of rental invalid. Expected {totalCost}. Real: {rent.CostTotal()}");
    }

    [Fact]
    public void Must_Finalize_Rental_After_Deadline_PlanFifteenDay()
    {
        var pan = PlanMock.GetPlanFifteenDays();
        var rent = new Rent(
                MotorcycleMock.GetMotorcycle(), 
                DeliverymanMock.GetDeliveryman(), 
                pan);
        
        var endDate = rent.ExpectedEndDate;
        var realEndDate = endDate.AddDays(5);
        var realCost = pan.CostPerDay * 20;
        var additionalCost = pan.AdditionalCostPerDay * 5;
        var totalCost = realCost + additionalCost;

        rent.FinalizeRental(realEndDate);

        Assert.True(rent.CostTotal() == totalCost, $"The cost of rental invalid. Expected {totalCost}. Real: {rent.CostTotal()}");
    }

     [Fact]
    public void Must_Finalize_Rental_In_Deadline_PlanThirtyDays()
    {
        var plan = PlanMock.GetPlanThirtyDays();
        var rent = new Rent(
                MotorcycleMock.GetMotorcycle(), 
                DeliverymanMock.GetDeliveryman(), 
                plan);
        
        var realEndDate = rent.ExpectedEndDate;
        var totalCost = plan.CostPerDay * plan.EndDay;

        rent.FinalizeRental(realEndDate);

        Assert.True(rent.CostTotal() == totalCost, $"The cost of rental invalid. Expected {totalCost}. Real: {rent.CostTotal()}");
    }


    [Fact]
    public void Must_Finalize_Rental_Before_Deadline_PlanThirtyDays()
    {
        var pan = PlanMock.GetPlanThirtyDays();
        var rent = new Rent(
                MotorcycleMock.GetMotorcycle(), 
                DeliverymanMock.GetDeliveryman(), 
                pan);
        
         var endDate = rent.ExpectedEndDate;
        var realEndDate = endDate.AddDays(-10);
        var realCost = pan.CostPerDay * 20;
        var fineCost = pan.CostPerDay * 10 * 0.6M;
        var totalCost = realCost + fineCost;

        rent.FinalizeRental(realEndDate);

        Assert.True(rent.CostTotal() == totalCost, $"The cost of rental invalid. Expected {totalCost}. Real: {rent.CostTotal()}");
    }

     [Fact]
    public void Must_Finalize_Rental_After_Deadline_PlanThirtyDays()
    {
        var pan = PlanMock.GetPlanThirtyDays();
        var rent = new Rent(
                MotorcycleMock.GetMotorcycle(), 
                DeliverymanMock.GetDeliveryman(), 
                pan);
        
        var endDate = rent.ExpectedEndDate;
        var realEndDate = endDate.AddDays(28);
        var realCost = pan.CostPerDay * 58;
        var additionalCost = pan.AdditionalCostPerDay * 28;
        var totalCost = realCost + additionalCost;

        rent.FinalizeRental(realEndDate);

        Assert.True(rent.CostTotal() == totalCost, $"The cost of rental invalid. Expected {totalCost}. Real: {rent.CostTotal()}");
    }
}
