namespace GideonMarket.Web.Client.Pages.Components.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ProductTypeId { get; set; }
        public int UnitId { get; set; }
        //public decimal Price { get; set; }
        public bool IsMaterial { get; set; }
    }
}
