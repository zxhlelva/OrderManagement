using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.ViewModel
{
    public class PlaceOrderViewModel
    {
        public ObservableCollection<PlaceOrderItemViewModel> Items { get; set; }    

        public PlaceOrderViewModel(MartketPriceItemViewModel model)
        {
            Items = new ObservableCollection<PlaceOrderItemViewModel>();
            PlaceOrderItemViewModel item = new PlaceOrderItemViewModel()
            {
                ProductId = model.ProductId,
                Price = model.OfferPrice,
                Quantity = model.OfferSize,
                Portfolio = new List<string>()
                {
                    "Default"
                }
            };

            Items.Add(item);
        }
    }
}
