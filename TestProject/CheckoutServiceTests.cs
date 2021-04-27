using Core.Interfaces;
using Core.Models;
using Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace TestProject
{
    [TestClass]
    public class CheckoutServiceTests
    {
        [TestMethod]
        //Prove you can scan an item at a checkout
        public void CanItemScanAndReturnItem()
        {
            // Arrange
            Item testItem = new Item { SKU = "A123", ItemPrice = 0.50m };
            var mockRepo = new Mock<ICheckoutRepository>();
            mockRepo.Setup(repo => repo.GetItem(testItem.SKU))
                .Returns(testItem);
            var itemService = new CheckoutService(mockRepo.Object);
            //Act
            Item result = itemService.ScanItem(testItem.SKU);
            //Assert
            Assert.AreEqual(result, testItem);
        }
        [TestMethod]
        //Prove you can request the total price
        public void CanIRequestTotalPrice()
        {
            // Arrange
            IEnumerable<string> testItems = new List<string>() { "A19", "B15", "C40" };
            var mockRepo = CreateTestRepository();
            var itemService = new CheckoutService(mockRepo.Object);

            //Act
            var result = itemService.TotalOfItems(testItems);

            //Assert
            Assert.AreEqual(result, 0.50m + 0.30m + 0.60m);
        }
        public static Mock<ICheckoutRepository> CreateTestRepository()
        {

            IEnumerable<Item> testItem = new List<Item>()
            {
                new Item { SKU = "A19", ItemPrice = 0.50m },
                new Item { SKU = "B15", ItemPrice = 0.30m },
                new Item { SKU = "C40", ItemPrice = 0.60m }
            };
  
            var mockRepo = new Mock<ICheckoutRepository>();
            foreach (var item in testItem)
            {
                mockRepo.Setup(repo => repo.GetItem(item.SKU))
                      .Returns(item);
            }
             return mockRepo;
        }
    }
}
