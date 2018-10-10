using System;
using System.Collections.Generic;

namespace Maddy.Apps.Expenditure.Entities
{
    public class TransactionType
    {
        public TransactionType()
        {
            Expenditures = new List<Expenditure>();
        }

        public int Id { get; set; }

        public string Type { get; set; }

        public List<Expenditure> Expenditures { get; set; }
    }
}
