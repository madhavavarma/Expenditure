using Maddy.Apps.Expenditure.DataProvider.Contexts;
using Maddy.Apps.Expenditure.Entities;

namespace Maddy.Apps.Expenditure.DataProvider.Repositories
{
    public class FilterRepository : GenericRepository<Filter>, IFilterRepository
    {
        public FilterRepository(ExpenditureContext expenditureContext) : base(expenditureContext)
        {
        }
    }
}
