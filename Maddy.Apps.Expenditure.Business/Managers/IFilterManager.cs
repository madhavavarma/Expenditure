using Maddy.Apps.Expenditure.Entities;
using Maddy.Apps.Expenditure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Maddy.Apps.Expenditure.Business.Managers
{
    public interface IFilterManager
    {
        Task<IEnumerable<FilterModel>> SearchAsync(string partialFilterName);
    }
}
