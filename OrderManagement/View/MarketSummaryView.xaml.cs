﻿using OrderManagement.Interface;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OrderManagement.View
{
    /// <summary>
    /// MarketSummaryView.xaml 的交互逻辑
    /// </summary>
    public partial class MarketSummaryView : UserControl, IMarketSummaryView
    {
        MarketSummaryViewModel _vm;
        public MarketSummaryView(MarketSummaryViewModel vm)
        {
            InitializeComponent();
            _vm = vm; 
            DataContext = _vm;
            _vm.LoadList();
        }
    }
}