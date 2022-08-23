using OrderManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Service
{
    public abstract class PriceService : IPriceService
    {
        public event EventHandler<MartketPriceUpdatedEventArgs> MartketPriceUpdated;

        protected void OnMartketPriceUpdated(IList<ProductMarket> items)
        {
            MartketPriceUpdated?.Invoke(this, new MartketPriceUpdatedEventArgs { Items = items });
        }

        public virtual Task<IEnumerable<ProductMarket>> GetList()
        {
            throw new NotImplementedException();
        }
    }

    public class MartketPriceUpdatedEventArgs
    {
        public IList<ProductMarket> Items { get; set; }
    }
}
