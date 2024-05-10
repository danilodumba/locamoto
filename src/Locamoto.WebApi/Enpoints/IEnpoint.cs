namespace Locamoto.WebApi.Enpoints;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}