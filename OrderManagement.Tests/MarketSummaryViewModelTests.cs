using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OrderManagement.Interface;
using OrderManagement.Model;
using OrderManagement.Service;
using OrderManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Tests
{
    [TestClass]
    public class MarketSummaryViewModelTests
    {
        [TestMethod]
        public void Can_Load_MartkeySummary_List()
        {
            var result = new ProductMarket[] { new ProductMarket
                {
                    ProductId = "BABA",
                    BidPrice = 89.63,
                    OfferPrice = 89.7,
                    BidSize = 2000,
                    OfferSize = 1200
                },
                new ProductMarket
                {
                    ProductId = "NIO",
                    BidPrice = 19.05,
                    OfferPrice = 19.2,
                    BidSize = 1000,
                    OfferSize = 200
                }
            };
            var priceService = new Mock<IPriceService>();
            priceService.Setup(p => p.GetList()).Returns(Task.FromResult(result.AsEnumerable()));
            var log = new Mock<ILog>();
            var messageService = new Mock<IMessageService>();
            var vm = new MarketSummaryViewModel(priceService.Object, log.Object, messageService.Object);

            vm.LoadList();
            Assert.IsNotNull(vm.Items);
            Assert.AreEqual(2, vm.Items.Count);
        }
    }
}
