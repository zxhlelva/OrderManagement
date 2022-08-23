using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderManagement.Model;
using OrderManagement.ViewModel;
using System;

namespace OrderManagement.Tests
{
    [TestClass]
    public class OMSObservableCollectionTests
    {
        [TestMethod]
        public void Can_Init_Collection()
        {
            var items = new MartketPriceItemViewModel[]
            {
                new MartketPriceItemViewModel(new ProductMarket
                {
                    ProductId = "NIO",
                    BidPrice = 19.05,
                    OfferPrice = 19.2,
                    BidSize = 1000,
                    OfferSize = 200
                })
                ,
                new MartketPriceItemViewModel(new ProductMarket
                {
                    ProductId = "BABA",
                    BidPrice = 89.63,
                    OfferPrice = 89.7,
                    BidSize = 2000,
                    OfferSize = 1200
                })
            };

            var collection = new OMSObservableCollection<MartketPriceItemViewModel>(items, (i) => i.ProductId);

            Assert.IsNotNull(collection);
            Assert.IsNotNull(collection["BABA"]);
            Assert.AreEqual(89.7, collection["BABA"].OfferPrice);
            Assert.AreEqual(89.63, collection["BABA"].BidPrice);
            Assert.AreEqual(2000, collection["BABA"].BidSize);
            Assert.AreEqual(1200, collection["BABA"].OfferSize);

            Assert.IsNotNull(collection["NIO"]);
            Assert.AreEqual(19.2, collection["NIO"].OfferPrice);
            Assert.AreEqual(19.05, collection["NIO"].BidPrice);
            Assert.AreEqual(1000, collection["NIO"].BidSize);
            Assert.AreEqual(200, collection["NIO"].OfferSize);

        }

        [TestMethod]
        public void Can_Update_Item()
        {
            var items = new MartketPriceItemViewModel[]
            {
                new MartketPriceItemViewModel(new ProductMarket
                {
                    ProductId = "NIO",
                    BidPrice = 19.05,
                    OfferPrice = 19.2,
                    BidSize = 1000,
                    OfferSize = 200
                })
                ,
                new MartketPriceItemViewModel(new ProductMarket
                {
                    ProductId = "BABA",
                    BidPrice = 89.63,
                    OfferPrice = 89.7,
                    BidSize = 2000,
                    OfferSize = 1200
                })
            };

            var collection = new OMSObservableCollection<MartketPriceItemViewModel>(items, (i) => i.ProductId);

            var toUpdate = new MartketPriceItemViewModel(new ProductMarket
            {
                ProductId = "NIO",
                BidPrice = 19.15,
                OfferPrice = 19.3,
                BidSize = 1200,
                OfferSize = 300
            });

            collection.Update(toUpdate);

            Assert.IsNotNull("NIO");
            Assert.AreEqual(19.3, collection["NIO"].OfferPrice);
            Assert.AreEqual(19.15, collection["NIO"].BidPrice);
            Assert.AreEqual(1200, collection["NIO"].BidSize);
            Assert.AreEqual(300, collection["NIO"].OfferSize);
        }
    }
}
