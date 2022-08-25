using OrderManagement.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.ViewModel
{
    public class PlaceOrderWindowViewModel
    {
        public PlaceOrderWindowViewModel(IPlaceOrderView placeOrderView)
        {
            PlaceOrderView = placeOrderView;
        }

        public IPlaceOrderView PlaceOrderView { get; set; }
    }
}
