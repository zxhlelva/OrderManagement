using OrderManagement.Interface;
using OrderManagement.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.ViewModel
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel(IMarketSummaryView summaryView)
        {
            SummaryView = summaryView;
        }

        public IMarketSummaryView SummaryView { get; set; }
    }
}
