using GideonMarket.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GideonMarket.Domain.Models
{
   public class Income : Entity, MainEntity
    {
        public string Description { get; private set; }
        public int Number { get; private set; }
        public DateTime RegDt { get; private set; }

        public List<IncomeItem> IncomeItems { get; private set; }

        public Income(string description, int number, DateTime regDt)
        {
            Description = description;
            Number = number;
            RegDt = regDt;
        }
        public void AddItem(IncomeItem orderItem)
        {
            ValidateItem(orderItem);
            IncomeItems.Add(orderItem);
        }

        public decimal GetTotalPrice()
        {
            return IncomeItems.Sum(x => x.Total);
        }

        private void ValidateItem(IncomeItem incomeItem)
        {
            //if (incomeItem == null)
            //    throw new IncomeItemException($"{nameof(IncomeItem)} не может быть Null");
            //if (incomeItem.IncomeId != Id)
            //    throw new IncomeItemException($"не возможно добавить запись прихода который не принадлежит этому приходу");
        }
    }
}
