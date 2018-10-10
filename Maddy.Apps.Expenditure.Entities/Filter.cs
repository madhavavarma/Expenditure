using System;
using System.Collections.Generic;

namespace Maddy.Apps.Expenditure.Entities
{
    public class Filter
    {
        public Filter()
        {
            ExpenditureFilters = new List<ExpenditureFilter>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public List<ExpenditureFilter> ExpenditureFilters { get; set; }
    }
}
