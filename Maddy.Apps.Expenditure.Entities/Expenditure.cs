using System;
using System.Collections.Generic;
using System.Text;

namespace Maddy.Apps.Expenditure.Entities
{
    public class Expenditure
    {
        public Expenditure()
        {
            ExpenditureFilters = new List<ExpenditureFilter>();
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime DateTime { get; set; }

        public int ExpenditureTypeId { get; set; }

        public int TransactionTypeId { get; set; }

        public List<ExpenditureFilter> ExpenditureFilters { get; set; }
    }
}
