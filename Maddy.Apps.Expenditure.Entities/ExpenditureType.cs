using System;
using System.Collections.Generic;

namespace Maddy.Apps.Expenditure.Entities
{
    public class ExpenditureType : IEntity
    {
        public ExpenditureType()
        {
            Expenditures = new List<Expenditure>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public List<Expenditure> Expenditures { get; set; }
    }
}
