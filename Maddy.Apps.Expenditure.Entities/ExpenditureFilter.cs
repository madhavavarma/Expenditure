using System;
using System.Collections.Generic;
using System.Text;

namespace Maddy.Apps.Expenditure.Entities
{
    public class ExpenditureFilter : IEntity
    {
        public int Id { get; set; }

        public int ExpenditureId { get; set; } 

        public int FilterId { get; set; }

        public Filter Filter { get; set; }
    }
}
