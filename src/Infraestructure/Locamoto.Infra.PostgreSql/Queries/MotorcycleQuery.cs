using Dapper;
using Locamoto.Infra.EF.Contexts;
using Locamoto.Infra.PostgreSql.Core;
using Locamoto.UseCases.Motorcycles.Queries;
using Locamoto.UseCases.Motorcycles.Queries.Dtos;

namespace Locamoto.Infra.PostgreSql.Queries
{
    public class MotorcycleQuery(string connectionString) : QueryRepository(connectionString), IMotorcycleQuery
    {
        readonly string _tableName = LocamotoEFContextSchema.Motorcycle.TableName;
        readonly string _schema = LocamotoEFContextSchema.DefualtSchema;

        public async Task<IEnumerable<ListMotorcycleDto>> GetAllOrByPlate(string plate = "")
        {
            using var connection = this.GetConnection();
            //TODO: Change this query.
            var commandText = $"select * from {_schema}.\"{_tableName}\" ";
            if (!string.IsNullOrWhiteSpace(plate))
            {
                commandText += $"where \"Plate\" = @plate";
            }
             
            var list = await connection.QueryAsync<ListMotorcycleDto>(commandText, new {plate = plate });
            return list.ToList();
        }
    }
}