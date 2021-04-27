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
    }
}
