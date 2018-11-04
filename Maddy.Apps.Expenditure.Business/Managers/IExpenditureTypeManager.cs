using Maddy.Apps.Expenditure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Maddy.Apps.Expenditure.Business.Managers
{
    public interface IExpenditureTypeManager
    {
        Task<IEnumerable<ExpenditureTypeModel>> GetAllAsync();
    }
}
