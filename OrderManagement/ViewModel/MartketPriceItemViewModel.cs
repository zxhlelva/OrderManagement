using OrderManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.ViewModel
{
    public class MartketPriceItemViewModel : ViewModelBase
    {
        public string ProductId { get => _model.ProductId; }
        public int BidSize { get => _model.BidSize; }
        public int OfferSize { get => _model.OfferSize; }
        public double BidPrice { get => _model.BidPrice; }
        public double OfferPrice { get => _model.OfferPrice; }

        ProductMarket _model;
        public MartketPriceItemViewModel(ProductMarket model)
        {
            _model = model;
        }

        public void Update(ProductMarket model)
        {
            _model = model;
            OnPropertyChanged("BidSize");
            OnPropertyChanged("OfferSize");
            OnPropertyChanged("BidPrice");
            OnPropertyChanged("OfferPrice");
        }
    }
}
