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
                                            .Include(x => x.ExpenditureFilters)
                                            .ThenInclude(x => x.Filter)
                                            .IncludeMultiple(x => x.TransactionType,
                                                              x => x.ExpenditureType)

                                            .OrderByDescending(x => x.DateTime)
                                            .ToListAsync();

            var expenditureModels = mapper.Map<IEnumerable<Entities.Expenditure>, IEnumerable<ExpenditureModel>>(expenditures);

            // Move code to Automapper
            foreach (var expenditureModel in expenditureModels)
            {
                expenditureModel.Filters = expenditureModel.ExpenditureFilters.Select(x => x.Filter).ToList();
            }

            return expenditureModels;
        }

        public async Task<ExpenditureModel> GetByIdAsync(int id)
        {
            var expenditure = await this.expenditureRepository
                                                    .Query
                                                    .Include(x => x.ExpenditureFilters)
                                                    .ThenInclude(x => x.Filter)
                                                    .Where(x => x.Id == id)
                                                    .FirstOrDefaultAsync();

            var expenditureModel = mapper.Map<ExpenditureModel>(expenditure);

            expenditureModel.Filters = expenditureModel.ExpenditureFilters.Select(x => x.Filter).ToList();

            return expenditureModel;
        }

        public async Task<bool> Save(ExpenditureModel expenditureModel)
        {
            if(expenditureModel.Id > 0)
            {
                var expenditure = await this.expenditureRepository.GetByIdAsync(expenditureModel.Id);

               mapper.Map<ExpenditureModel, Entities.Expenditure>(expenditureModel, expenditure);

                await this.expenditureRepository.UpdateAsync(expenditure.Id, expenditure);

                await this.UpdateExpenditureFilters(expenditureModel.Filters, expenditure.Id);
            }
            else
            {
                var expenditure = mapper.Map<ExpenditureModel, Entities.Expenditure>(expenditureModel);

                await this.expenditureRepository.CreateAsync(expenditure);

                await this.AddExpenditureFilters(expenditureModel.Filters, expenditure.Id);
            }

            return true;
        }

        public async Task AddExpenditureFilters(List<FilterModel> filterModels, int expenditureId)
        {
            filterModels.ForEach(filterModel => 
            {
                var expenditureFilter = new ExpenditureFilter()
                {
                    ExpenditureId = expenditureId,
                    FilterId = filterModel.Id
                };

                this.expenditureFilterRepository.Context.Add(expenditureFilter);
            });

            await this.expenditureFilterRepository.Context.SaveChangesAsync();
        }

        public async Task UpdateExpenditureFilters(List<FilterModel> filterModels, int expenditureId)
        {
            var expenditure = await this.expenditureRepository
                                  .GetByIdAsync(expenditureId, x => x.ExpenditureFilters);


            var addList = filterModels
                                .Where(filterModel => !expenditure
                                                          .ExpenditureFilters
                                                          .Where(expenditureFilter => expenditureFilter.FilterId == filterModel.Id)
                                                          .Any())
                                .ToList();

            var deleteList = expenditure
                                .ExpenditureFilters
                                .Where(expenditureFilter => !filterModels
                                                               .Where(filterModel => expenditureFilter.FilterId == filterModel.Id)
                                                               .Any())
                                .ToList();

            foreach(var deleteItem in deleteList)
            {
                await this.expenditureFilterRepository.DeleteAsync(deleteItem.Id);
            }

           await this.AddExpenditureFilters(addList, expenditureId);            
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
