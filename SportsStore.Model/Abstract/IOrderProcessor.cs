using SportsStore.Model.Entities;

namespace SportsStore.Model.Abstract
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}
