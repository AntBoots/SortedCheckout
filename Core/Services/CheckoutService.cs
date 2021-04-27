using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly ICheckoutRepository _checkoutRepository;
        public CheckoutService(ICheckoutRepository checkoutRepository)
        {
            _checkoutRepository = checkoutRepository;
        }
        //ScanItem presumes that when scanning the item an SKU is provided to use as a search
        public Item ScanItem(string SKU)
        {
            return _checkoutRepository.GetItem(SKU);
        }
        //TotalOfItems just expects a list of scanned items' SKU codes
        public decimal TotalOfItems(IEnumerable<string> items)
        {
            decimal totalCost = 0m;
            List<Item> itemsInFull = new List<Item>();
            foreach (var item in items)
            {
                var itemInFull = _checkoutRepository.GetItem(item);
                totalCost += itemInFull.ItemPrice;
                itemsInFull.Add(itemInFull);
                //Consider offers on items.....
                //Could put the discounting in own class/methods that can be abstracted to use for multiple types of offers/discounts
                var itemSpecialOffer = _checkoutRepository.GetSpecialOffer(item);
                if (itemSpecialOffer != null)
                {
                    var sameItemsSoFar = itemsInFull.Where(i => i.SKU == item).ToList();
                    //If no remainder then an exact offer quantity has been matched so apply offer
                    if (sameItemsSoFar.Count() % itemSpecialOffer.Quantity == 0)
                    {
                        //Work out difference between cost and the special offer and apply it to totalCost
                        totalCost += itemSpecialOffer.OfferPrice - (itemInFull.ItemPrice * itemSpecialOffer.Quantity);
                    }
                }
            }
            return totalCost;
        }
    }
}
