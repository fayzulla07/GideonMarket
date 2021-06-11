using GideonMarket.Entities.Shared;


namespace GideonMarket.Entities.Models
{
    public class IncomeItem : Entity
    {
        public int IncomeId { get; private set; }
        public int ProductId { get; private set; }
        public string Description { get; private set; }

        public double Count { get; private set; }
        public decimal Price { get; private set; }
        public IncomeItem()
        {

        }
        public IncomeItem(int incomeId, int productId, string description, double count, decimal price)
        {
            IncomeId = incomeId;
            ProductId = productId;
            Description = description;
            Count = count;
            Price = price;
        }
        public decimal Total
        {
            get { return Price * (decimal)Count; }
        }

        
    }
}
