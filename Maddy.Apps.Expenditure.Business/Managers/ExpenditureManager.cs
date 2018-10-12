using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Maddy.Apps.Expenditure.DataProvider.Contexts;
using Maddy.Apps.Expenditure.DataProvider.Repositories;
using Maddy.Apps.Expenditure.Entities;
using Maddy.Apps.Expenditure.Models;
using Microsoft.EntityFrameworkCore;

namespace Maddy.Apps.Expenditure.Business.Managers
{
    public class ExpenditureManager : IExpenditureManager
    {
        public IExpenditureRepository expenditureRepository;

        private readonly IMapper mapper;

        public ExpenditureManager(IExpenditureRepository expenditureRepository, IMapper mapper)
        {
            this.expenditureRepository = expenditureRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ExpenditureModel>> Search()
        {
            var expenditures = await this.expenditureRepository.GetAll(x => x.ExpenditureFilters).OrderBy(x => x.Id).ToListAsync();

            return mapper.Map<IEnumerable<Entities.Expenditure>, IEnumerable<ExpenditureModel>>(expenditures);
        }
    }
}
