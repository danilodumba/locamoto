using Locamoto.UseCases.Orders.Dtos;

namespace Locamoto.UseCases.Orders.Queries
{
    public interface IOrderDeliverymanNotificationQuery
    {
        Task<List<OrderDeliverymanNotifiedDto>> GetDeliverymanNotified();
    }
}