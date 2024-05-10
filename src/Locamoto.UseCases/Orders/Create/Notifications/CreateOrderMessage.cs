namespace Locamoto.UseCases.Orders.Create.Notifications
{
    public class CreateOrderMessage
    {
        public Guid OrderID { get; set; }
        public DateTime CreatedDate { get; set;}
        public decimal Cost { get; set; }
    }
}