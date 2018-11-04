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
    public class TransactionTypeManager : ITransactionTypeManager
    {
        public ITransactionTypeRepository transactionTypeRepository;

        private readonly IMapper mapper;

        public TransactionTypeManager(ITransactionTypeRepository transactionTypeRepository, IMapper mapper)
        {
            this.transactionTypeRepository = transactionTypeRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TransactionTypeModel>> GetAllAsync()
        {
            var transactionTypes = await this.transactionTypeRepository.GetAll().OrderBy(x => x.Id).ToListAsync();

            return mapper.Map<IEnumerable<TransactionType>, IEnumerable<TransactionTypeModel>>(transactionTypes);
        }
    }
}
