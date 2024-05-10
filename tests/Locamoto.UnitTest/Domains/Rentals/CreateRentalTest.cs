using Locamoto.Domain.Entities;
using Locamoto.Domain.Exceptions;
using Locamoto.UnitTest.Domains.Deliverymans;
using Locamoto.UnitTest.Domains.Motorcycles;
using Locamoto.UnitTest.Domains.Plans;

namespace Locamoto.UnitTest.Domains.Rentals
{
    public class CreateRentalTest
    {
        [Fact]
        public void Must_Create_Rental_With_Valid_EndDate()
        {
            var endDate = DateOnly.FromDateTime(DateTime.Now.AddDays(31));
            
            var rent = new Rent(
                MotorcycleMock.GetMotorcycle(), 
                DeliverymanMock.GetDeliveryman(), 
                PlanMock.GetPlanThirtyDays());

            Assert.True(rent.ExpectedEndDate == endDate, "End date is not correct.");
        }

        [Fact]
        public void Must_Create_Rental_With_Valid_StartDate()
        {
            var startDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
           
            var rent = new Rent(
                MotorcycleMock.GetMotorcycle(), 
                DeliverymanMock.GetDeliveryman(), 
                PlanMock.GetPlanSevenDays());

            Assert.True(rent.StartDate == startDate, "Start date is not correct.");
        }

        [Fact]
        public void Must_Create_Rental_With_Valid_ExpectedCost()
        {
            var plan = PlanMock.GetPlanFifteenDays();
            var cost = plan.EndDay * plan.CostPerDay;

            var rent = new Rent(
                MotorcycleMock.GetMotorcycle(), 
                DeliverymanMock.GetDeliveryman(), 
                plan);

            Assert.True(rent.ExpectedCost == cost, "Expected cost date is not correct.");
        }

        [Fact]
        public void Must_Create_Rental_With_Valid_MotorcycleUnavaliable()
        {
            var rent = new Rent(
                MotorcycleMock.GetMotorcycle(), 
                DeliverymanMock.GetDeliveryman(), 
                PlanMock.GetPlanFifteenDays());

            Assert.False(rent.Motorcycle.Available, "Motorcycle is not unavaliable.");
        }

        [Fact]
        public void Must_Create_Rental_With_Invalid_DeliverymanCnhTypeB()
        {
            Assert.Throws<DomainException>(() => {
                var rent = new Rent(
                    MotorcycleMock.GetMotorcycle(), 
                    DeliverymanMock.GetDeliverymanCnhTypeB(), 
                    PlanMock.GetPlanFifteenDays());
            });
        }
    }
}