using GideonMarket.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GideonMarket.Entities.Models
{
   public class Income : Entity, MainEntity
    {
        public string Description { get; private set; }
        public int Number { get; private set; }
        public DateTime RegDt { get; private set; }

        public List<IncomeItem> IncomeItems { get; private set; }

        public Income()
        {

        }
        public Income(string description, int number, DateTime regDt)
        {
            Description = description;
            Number = number;
            RegDt = regDt;
        }
        public void AddItem(IncomeItem orderItem)
        {
            IncomeItems.Add(orderItem);
        }

        public decimal GetTotalPrice()
        {
            return IncomeItems.Sum(x => x.Total);
        }


    }
}
