using System;
using System.Collections.Generic;
using System.Text;

namespace Maddy.Apps.Expenditure.Models
{
    public class ExpenditureFilterModel
    {
        public int Id { get; set; }

        public int ExpenditureId { get; set; } 

        public int FilterId { get; set; }

        public FilterModel Filter { get; set; }
    }
}
