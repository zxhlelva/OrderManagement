using OrderManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Data.Interface.Service
{
    public interface IProductMarketDataService
    {
        Task<List<ProductMarket>> GetProductMarketList(IList<string> productIds);
    }
}
