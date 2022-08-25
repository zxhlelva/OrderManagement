using OrderManagement.Interface;
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

        private void CbxLanguage_DropDownClosed(object sender, EventArgs e)
        {
            int selectedLanguageIndex = CbxLanguage.SelectedIndex;

            string requestedCulture = string.Empty;

            ResourceDictionary dict = new ResourceDictionary();

            if (selectedLanguageIndex == 0)
            {
                //dict.Source = new Uri(@"Resource\Language\ZH.xaml", UriKind.Relative);
                requestedCulture = @"Resource\Language\ZH.xaml";
            }
            else
            {
                //dict.Source = new Uri(@"Resource\Language\EN.xaml", UriKind.Relative);
                requestedCulture = @"Resource\Language\EN.xaml";
            }

            //Application.Current.Resources.MergedDictionaries[0] = dict;

            List<ResourceDictionary> dictionaryList = new List<ResourceDictionary>();
            foreach (ResourceDictionary dictionary in Application.Current.Resources.MergedDictionaries)
            {
                dictionaryList.Add(dictionary);
            }

            ResourceDictionary resourceDictionary = dictionaryList.FirstOrDefault(d => d.Source.OriginalString.Equals(requestedCulture));
            Application.Current.Resources.MergedDictionaries.Clear();
            //Application.Current.Resources.MergedDictionaries.Remove(resourceDictionary);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("New Window");
        }
    }
}
