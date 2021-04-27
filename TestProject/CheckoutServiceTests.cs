using Core.Interfaces;
using Core.Models;
using Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

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
    }
}
