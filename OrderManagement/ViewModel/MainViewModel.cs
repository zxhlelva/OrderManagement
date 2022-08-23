using OrderManagement.Interface;
using OrderManagement.Service;
using System;
using System.Collections.ObjectModel;

namespace OrderManagement.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        IMessageService _messageService;
        ILog _log;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IPriceService priceService , ILog log, IMessageService messageService)
        {
            this._messageService = messageService;
            this._log = log;
        }
    }
}