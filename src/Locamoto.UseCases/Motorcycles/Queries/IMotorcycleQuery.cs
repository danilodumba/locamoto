
using Locamoto.UseCases.Motorcycles.Queries.Dtos;

namespace Locamoto.UseCases.Motorcycles.Queries;

public interface IMotorcycleQuery
{
    Task<IEnumerable<ListMotorcycleDto>> GetAllOrByPlate(string plate = "");
}
