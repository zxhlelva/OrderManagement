using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Interface;
using OrderManagement.Model;
using OrderManagement.Service;

namespace OrderManagement.ViewModel
{
    public class MarketSummaryViewModel : ViewModelBase
    {
        IPriceService _priceService;
        IMessageService _messageService;
        ILog _log;
        OMSObservableCollection<MartketPriceItemViewModel> _items;

        /// <summary>
        /// Initializes a new instance of the MarketSummaryViewModel class.
        /// </summary>
        public MarketSummaryViewModel(IPriceService priceService, ILog log, IMessageService messageService)
        {
            this._messageService = messageService;
            this._log = log;
            this._priceService = priceService;
            this._priceService.MartketPriceUpdated += PriceService_MartketPriceUpdated;
        }

        public OMSObservableCollection<MartketPriceItemViewModel> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public async Task Init()
        {
            try
            {
                await _priceService.InitMarket();
            }
            catch (Exception ex)
            {
                _messageService.ShowMessage("Error", ex.Message);
            }
        }

        public async Task LoadList()
        {
            try
            {
                var list = await _priceService.GetList();

                Items = new OMSObservableCollection<MartketPriceItemViewModel>(list.Select(i => new MartketPriceItemViewModel(i)), (i) => i.ProductId);

            }
            catch (Exception ex)
            {
                _messageService.ShowMessage("Error", ex.Message);
            }
        }

        private void PriceService_MartketPriceUpdated(object sender, MartketPriceUpdatedEventArgs e)
        {
            foreach (var item in e.Items)
            {
                ExecuteOnUIThread(() =>_items[item.ProductId].Update(item));
            }
        }

    }
}
