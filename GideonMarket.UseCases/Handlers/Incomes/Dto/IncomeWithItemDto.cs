using System;

namespace GideonMarket.UseCases.Handlers.Incomes.Dto
{
    public class IncomeWithItemDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public DateTime RegDt { get; set; }
        public int IncomeItemId { get; set; }
        public int ProductId { get; set; }
        public string DescriptionItem { get; set; }
        public double Count { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public int SupplierId { get; set; }
    }
}
