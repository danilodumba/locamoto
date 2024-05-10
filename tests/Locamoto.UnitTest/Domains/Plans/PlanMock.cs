using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locamoto.Domain.Entities;

namespace Locamoto.UnitTest.Domains.Plans
{
    public static class PlanMock
    {
        public static CostPlan GetPlanSevenDays()
        {
            return new CostPlan(7, 7, 30, 20, 50);
        }

        public static CostPlan GetPlanFifteenDays()
        {
            return new CostPlan(15, 15, 28, 40, 50);
        }

        public static CostPlan GetPlanThirtyDays()
        {
            return new CostPlan(30, 30, 22, 60, 50);
        }
    }
}