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
                Portfolio = new ObservableCollection<string>()
                {
                    "Default"
                }
            };
        }

        public PlaceOrderViewModel()
        {
            Items = new ObservableCollection<PlaceOrderItemViewModel>();
            PlaceOrderItemViewModel item = new PlaceOrderItemViewModel()
            {
                ProductId = "11111",
                Price = 15,
                Quantity = 15,
                Portfolio = new ObservableCollection<string>()
                {
                    "Default"
                }
            };

            Items.Add(item);
        }
    }
}
