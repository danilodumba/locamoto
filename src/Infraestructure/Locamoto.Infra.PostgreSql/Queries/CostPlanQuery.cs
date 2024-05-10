using Dapper;
using Locamoto.Infra.EF.Contexts;
using Locamoto.Infra.PostgreSql.Core;
using Locamoto.UseCases.CostPlans.Dtos;
using Locamoto.UseCases.CostPlans.Queries;

namespace Locamoto.Infra.PostgreSql.Queries
{
    public class CostPlanQuery : QueryRepository, ICostPlanServiceQuery
    {
        public CostPlanQuery(string connectionString) : base(connectionString)
        {
        }

        public async Task<List<CosPlanDto>> GetAll()
        {
           using var connection = this.GetConnection();

            string commandText = $@"
                SELECT * FROM locamoto.""{LocamotoEFContextSchema.CostPlan.TableName}""
                order by ""{LocamotoEFContextSchema.CostPlan.Description}""";

            var plans = await connection.QueryAsync<CosPlanDto>(commandText);
            return plans.ToList();
        }
    }
}