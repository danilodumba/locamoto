using Locamoto.UseCases.Core;

namespace Locamoto.UseCases.Orders.Create;

public record CreateOrderCommand(decimal Cost): CommandRequest<CreateOrderResponse>;
