namespace GideonMarket.Web.Client.Pages.Components.Material
{
    public class MaterialViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ProductTypeId { get; set; }
        public int UnitId { get; set; }
        public decimal Price { get; set; }
        public bool IsMaterial => true;
    }
}
