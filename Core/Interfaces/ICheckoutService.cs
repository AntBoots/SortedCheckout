using Core.Models;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface ICheckoutService
    {
        Item ScanItem(string SKU);
        decimal TotalOfItems(IEnumerable<string> items);
    }
}
