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
    public class ExpenditureTypeManager : IExpenditureTypeManager
    {
        public IExpenditureTypeRepository expenditureTypeRepository;

        private readonly IMapper mapper;

        public ExpenditureTypeManager(IExpenditureTypeRepository expenditureTypeRepository, IMapper mapper)
        {
            this.expenditureTypeRepository = expenditureTypeRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ExpenditureTypeModel>> GetAllAsync()
        {
            var expenditureTypes = await this.expenditureTypeRepository.GetAll().OrderBy(x => x.Id).ToListAsync();

            return mapper.Map<IEnumerable<ExpenditureType>, IEnumerable<ExpenditureTypeModel>>(expenditureTypes);
        }
    }
}
