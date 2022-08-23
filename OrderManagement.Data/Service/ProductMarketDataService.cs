using System.Text.Json;
using OrderManagement.Data.Interface.Service;
using OrderManagement.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Data.Service
{
    public class ProductMarketDataService : IProductMarketDataService
    {
        private const string CONNECTION_STRING = "Data/ProductMarket.json";
        public async Task<List<ProductMarket>> GetProductMarketList(IList<string> productIds)
        {
            using (StreamReader reader = new StreamReader(CONNECTION_STRING))
            {
                string productMarketData = await reader.ReadToEndAsync();
                List<ProductMarket> productMarketList = JsonSerializer.Deserialize<List<ProductMarket>>(productMarketData);

                var query = from item in productMarketList
                            where productIds.Contains(item.ProductId)
                            select item;

                return query.ToList();
            }
        }
    }
}
