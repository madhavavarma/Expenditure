using Maddy.Apps.Expenditure.DataProvider.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maddy.Apps.Expenditure.DataProvider.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddDataProviderDI(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IExpenditureTypeRepository, ExpenditureTypeRepository>();

            serviceCollection.AddTransient<ITransactionTypeRepository, TransactionTypeRepository>();

            serviceCollection.AddTransient<IFilterRepository, FilterRepository>();

            serviceCollection.AddTransient<IExpenditureRepository, ExpenditureRepository>();

            serviceCollection.AddTransient<IExpenditureFilterRepository, ExpenditureFilterRepository>();
        }
    }
}
