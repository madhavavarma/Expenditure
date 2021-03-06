﻿using Maddy.Apps.Expenditure.DataProvider.Contexts;
using Maddy.Apps.Expenditure.Entities;
using Maddy.Apps.Expenditure.Models;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Maddy.Apps.Expenditure.DataProvider.Repositories
{
    public class ExpenditureFilterRepository : GenericRepository<Entities.ExpenditureFilter>, IExpenditureFilterRepository
    {
        public ExpenditureFilterRepository(ExpenditureContext expenditureContext) : base(expenditureContext)
        {
        }
    }
}
