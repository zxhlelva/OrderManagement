using OrderManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OrderManagement.View
{
    /// <summary>
    /// Interaction logic for PlaceOrderWindow.xaml
    /// </summary>
    public partial class PlaceOrderWindow : Window
    {
        PlaceOrderWindowViewModel _vm;
        public PlaceOrderWindow(PlaceOrderWindowViewModel vm)
        {
            InitializeComponent();
            _vm = vm;
            DataContext = _vm;
        }
    }
}
