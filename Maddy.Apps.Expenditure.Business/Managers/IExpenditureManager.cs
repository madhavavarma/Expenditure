using Maddy.Apps.Expenditure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Maddy.Apps.Expenditure.Business.Managers
{
    public interface IExpenditureManager
    {
        Task<IEnumerable<ExpenditureModel>> Search();

        Task<ExpenditureModel> GetByIdAsync(int id);

        Task<bool> Save(ExpenditureModel expenditureModel);

        Task<bool> DeleteAsync(int id);
    }
}
