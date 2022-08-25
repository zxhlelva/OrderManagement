using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.ViewModel
{
    public class PlaceOrderItemViewModel
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public ObservableCollection<string> Portfolio { get; set; }
    }
}
