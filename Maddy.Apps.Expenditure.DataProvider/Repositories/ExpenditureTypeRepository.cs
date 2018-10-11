using Maddy.Apps.Expenditure.DataProvider.Contexts;
using Maddy.Apps.Expenditure.Entities;

namespace Maddy.Apps.Expenditure.DataProvider.Repositories
{
    public class ExpenditureTypeRepository : GenericRepository<ExpenditureType>, IExpenditureTypeRepository
    {
        public ExpenditureTypeRepository(ExpenditureContext expenditureContext) : base(expenditureContext)
        {
        }
    }
}
