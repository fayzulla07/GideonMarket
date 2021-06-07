using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.Incomes
{
    public class IncomeItemDto
    {
        public int Id { get; set; }
        public int IncomeId { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
        public double Count { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }
}
