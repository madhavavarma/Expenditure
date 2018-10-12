using AutoMapper;
using Maddy.Apps.Expenditure.Entities;
using Maddy.Apps.Expenditure.Models;
using System.Collections.Generic;

namespace Maddy.Apps.Expenditure.Business.Infrastructure.AutoMapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<ExpenditureType, ExpenditureTypeModel>();
            CreateMap<TransactionType, TransactionTypeModel>();
            CreateMap<Filter, FilterModel>();
            
        }
    }
}
