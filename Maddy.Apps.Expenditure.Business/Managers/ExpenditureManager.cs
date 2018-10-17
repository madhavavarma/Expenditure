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
using Maddy.Apps.Expenditure.Business.Infrastructure.Extensions;

namespace Maddy.Apps.Expenditure.Business.Managers
{
    public class ExpenditureManager : IExpenditureManager
    {
        public IExpenditureRepository expenditureRepository;

        public IExpenditureFilterRepository expenditureFilterRepository;

        private readonly IMapper mapper;

        public ExpenditureManager(IExpenditureRepository expenditureRepository, IExpenditureFilterRepository expenditureFilterRepository, IMapper mapper)
        {
            this.expenditureRepository = expenditureRepository;
            this.expenditureFilterRepository = expenditureFilterRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ExpenditureModel>> Search()
        {
            var expenditures = await this.expenditureRepository
                                            .GetAll()
                                            .IncludeMultiple(x => x.ExpenditureFilters,
                                                                  x => x.TransactionType,
                                                                  x => x.ExpenditureType)
                                            .OrderByDescending(x => x.Id)
                                            .ToListAsync();

            return mapper.Map<IEnumerable<Entities.Expenditure>, IEnumerable<ExpenditureModel>>(expenditures);
        }

        public async Task<bool> Save(ExpenditureModel expenditureModel)
        {
            if(expenditureModel.Id > 0)
            {
                var expenditure = await this.expenditureRepository.GetByIdAsync(expenditureModel.Id);

               mapper.Map<ExpenditureModel, Entities.Expenditure>(expenditureModel, expenditure);

                foreach(var expenditureFilterModel in expenditureModel.ExpenditureFilters)
                {
                    if(expenditureFilterModel.Id > 0)
                    {
                        var expenditureFilter = expenditure.ExpenditureFilters.SingleOrDefault(x => x.Id == expenditureFilterModel.Id);

                        mapper.Map<ExpenditureFilterModel, Entities.ExpenditureFilter>(expenditureFilterModel, expenditureFilter);

                        await this.expenditureFilterRepository.UpdateAsync(expenditureFilter.Id, expenditureFilter);
                    }
                    else
                    {
                        var expenditureFilter = mapper.Map<ExpenditureFilterModel, Entities.ExpenditureFilter>(expenditureFilterModel);

                        await this.expenditureFilterRepository.CreateAsync(expenditureFilter);
                    }
                }

                await this.expenditureRepository.UpdateAsync(expenditure.Id, expenditure);
            }
            else
            {
                var expenditure = mapper.Map<ExpenditureModel, Entities.Expenditure>(expenditureModel);

                await this.expenditureRepository.CreateAsync(expenditure);
            }

            return true;
        }

        public void AddOrUpdateExpenditureFilters(ExpenditureModel expenditureModel, Entities.Expenditure expenditure)
        {
            foreach (var expenditureFilter in expenditureModel.ExpenditureFilters)
            {
                if (expenditureFilter.Id == 0)
                {
                    expenditure.ExpenditureFilters.Add(mapper.Map<ExpenditureFilter>(expenditureFilter));
                }
                else
                {
                    mapper.Map(expenditureFilter, expenditure.ExpenditureFilters.SingleOrDefault(c => c.Id == expenditureFilter.Id));
                }
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await this.expenditureRepository.DeleteAsync(id);

            return true;
        }
    }
}
