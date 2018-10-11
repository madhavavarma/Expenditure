using Maddy.Apps.Expenditure.Business.Managers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maddy.Apps.Expenditure.Business.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddBusinessDI(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IExpenditureTypeManager, ExpenditureTypeManager>();

            serviceCollection.AddTransient<ITransactionTypeManager, TransactionTypeManager>();
        }
    }
}
