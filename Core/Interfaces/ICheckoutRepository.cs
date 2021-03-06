using Core.Models;

namespace Core.Interfaces
{
    public interface ICheckoutRepository
    {
        Item GetItem(string SKU);
        SpecialOffer GetSpecialOffer(string SKU);
    }
}
