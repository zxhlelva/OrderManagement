using OrderManagement.Data.Interface.Service;
using OrderManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderManagement.Service
{
    public class DemoPriceService : PriceService
    {
        Timer _timer;
        IProductMarketDataService _productMarketDataService;
        IProductDataService _productDataService;
        List<ProductMarket> _productMarketData;

        public DemoPriceService(IProductMarketDataService productMarketDataService, IProductDataService productDataService)
        {
            _productMarketDataService = productMarketDataService;
            _productDataService = productDataService;
            StartUpdate();
        }

        private async Task StartUpdate()
        {
            await InitMarket();
            _timer = new Timer(UpdateListPrice, null, TimeSpan.FromMilliseconds(500), TimeSpan.FromMilliseconds(500));
        }

        public async override Task InitMarket()
        {
            List<Product> productList = await _productDataService.GetProductList();
            var productIds = productList.Select(x => x.ProductId).ToList();
            var marketData = await _productMarketDataService.GetProductMarketList(productIds);
            _productMarketData = marketData;
            return;
        }

        public async override Task<IEnumerable<ProductMarket>> GetList()
        {
            return await Task.FromResult<IEnumerable<ProductMarket>>(_productMarketData);
        }

        private void UpdateListPrice(object state)
        {
            Random random = new Random();
            int dataCount = _productMarketData.Count;
            var index = random.Next(0, dataCount);
            double change = random.NextDouble() * random.Next(0, dataCount) / 100;
            var item = _productMarketData[index];
            var oldPrice = item.BidPrice;
            item.BidPrice = Math.Round(item.BidPrice * (1 + change), 2);
            item.BidSize = (int)Math.Round(item.BidSize * (1 + change * 100), 0);
            item.OfferPrice = Math.Round(item.BidPrice * (1 + change), 2);
            item.OfferSize = (int)Math.Round(item.BidSize * (1 + change * 100), 0);
            OnMartketPriceUpdated(new ProductMarket[] { item }.ToList());
            Console.WriteLine($"{item.ProductId} old price: {oldPrice} - new price:{item.BidPrice}");
        }
    }
}
