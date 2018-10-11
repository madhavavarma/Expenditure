using Maddy.Apps.Expenditure.DataProvider.Contexts;
using Maddy.Apps.Expenditure.Entities;

namespace Maddy.Apps.Expenditure.DataProvider.Repositories
{
    public class TransactionTypeRepository : GenericRepository<TransactionType>, ITransactionTypeRepository
    {
        public TransactionTypeRepository(ExpenditureContext expenditureContext) : base(expenditureContext)
        {
        }
    }
}
