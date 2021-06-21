using System.ComponentModel;

namespace GideonMarket.Web.Client.Pages.IncomePage
{
    public class IncomeItemViewModel : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public int IncomeId { get; set; }
        public int ProductId {
            get { return ProductId; }
            set
            {
                this.ProductId = value;
                NotifyPropertyChanged("ProductId");
            }
        }
        public string Description { get; set; }
        public double Count { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
