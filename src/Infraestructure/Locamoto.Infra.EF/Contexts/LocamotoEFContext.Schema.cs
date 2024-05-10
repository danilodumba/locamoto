
namespace Locamoto.Infra.EF.Contexts;
public static class LocamotoEFContextSchema
{
    public const string DefualtSchema = "locamoto";
    public const string DefualtConnectionStringName = "LocamotoConnection";

    public static class CostPlan
    {
        public const string TableName = "CostPlan";
        public const string Id = "Id";
        public const string StartDay = "StartDay";
        public const string EndDay = "EndDay";
        public const string CostPerDay = "CostPerDay";
        public const string AdditionalCostPerDay = "AdditionalCostPerDay";
        public const string PercentageFine = "PercentageFine";
        public const string Description = "Description";
    }

    public static class Deliveryman
    {
        public const string TableName = "Deliveryman";
        public const string Id = "Id";
        public const string Name = "Name";
        public const string Cnpj = "Cnpj";
        public const string CnhNumber = "CnhNumber";
        public const string CnhImage = "CnhImage";
        public const string CnhType = "CnhTipe";
    }


    public static class Motorcycle
    {
        public const string TableName = "Motorcycle";
        public const string Id = "Id";
        public const string Year = "Year";
        public const string Model = "Model";
        public const string Plate = "Plate";
        public const string Available = "Available";
    }

    public static class Order
    {
        public const string TableName = "Order";
        public const string Id = "Id";
        public const string CreatedAt = "CreatedAt";
        public const string Cost = "Cost";
        public const string Status = "Status";
        public const string DeliverymanID = "DeliverymanID";
    }

    public static class Rent
    {
        public const string TableName = "Rent";
        public const string Id = "Id";
        public const string StartDate = "StartDate";
        public const string CreatedDate = "CreatedDate";
        public const string ExpectedEndDate = "ExpectedEndDate";
        public const string EndDate = "EndDate";
        public const string ExpectedCost = "ExpectedCost";
        public const string FineCost = "FineCost";
        public const string RealCost = "RealCost";
        public const string Status = "Status";
        public const string DeliverymanID = "DeliverymanID";
        public const string PlanID = "PlanID";
        public const string MotorcycleID = "MotorcycleID";
    }
}
