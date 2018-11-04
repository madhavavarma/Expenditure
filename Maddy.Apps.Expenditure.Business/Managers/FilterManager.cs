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
    public class FilterManager : IFilterManager
    {
        public IFilterRepository FilterRepository;

        private readonly IMapper mapper;

        public FilterManager(IFilterRepository FilterRepository, IMapper mapper)
        {
            this.FilterRepository = FilterRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<FilterModel>> SearchAsync(string partialFilterName)
        {
            var Filters = await this.FilterRepository
                                    .GetAll()
                                    .Where(x => EF.Functions.Like(x.Name, $"%{partialFilterName}%"))
                                    .OrderBy(x => x.Id)
                                    .ToListAsync();

            return mapper.Map<IEnumerable<Filter>, IEnumerable<FilterModel>>(Filters);
        }

        public async Task AddFilter(FilterModel filterModel)
        {
            if (filterModel.Id > 0)
            {
                var filter = await this.FilterRepository.GetByIdAsync(filterModel.Id);

                mapper.Map<FilterModel, Filter>(filterModel, filter);

                await this.FilterRepository.UpdateAsync(filter.Id, filter);
            }
            else
            {
                var filter = mapper.Map<Filter>(filterModel);

                await this.FilterRepository.CreateAsync(filter);
            }
        }
    }
}
