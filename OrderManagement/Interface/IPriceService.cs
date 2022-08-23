using OrderManagement.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagement.Service
{
    public interface IPriceService
    {
        event EventHandler<MartketPriceUpdatedEventArgs> MartketPriceUpdated;

        Task InitMarket();

        Task<IEnumerable<ProductMarket>> GetList();
    }
}