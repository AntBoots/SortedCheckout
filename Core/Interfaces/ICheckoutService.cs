using Core.Models;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface ICheckoutService
    {
        Item ScanItem(string SKU);
    }
}
