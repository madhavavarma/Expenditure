using System;
using System.Collections.Generic;
using System.Text;

namespace Maddy.Apps.Expenditure.Models
{
    public class ExpenditureModel
    {
        public ExpenditureModel()
        {
            ExpenditureFilters = new List<ExpenditureFilterModel>();
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime DateTime { get; set; }

        public int ExpenditureTypeId { get; set; }

        public int TransactionTypeId { get; set; }

        public List<ExpenditureFilterModel> ExpenditureFilters { get; set; }
    }
}
