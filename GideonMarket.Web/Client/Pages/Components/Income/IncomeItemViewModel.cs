namespace GideonMarket.Web.Client.Pages.Income
{
    public class IncomeItemViewModel 
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
        public double Count { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }
}
