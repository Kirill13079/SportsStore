using SportsStore.Model.Abstract;
using SportsStore.Model.Entities;

namespace SportsStore.Model.Concrete
{
    public class SettingsUser
    {

    }

    public class EmailOrderProcessor : IOrderProcessor
    {
        private readonly SettingsUser _emailSettings;

        public EmailOrderProcessor(SettingsUser settings)
        {
            _emailSettings = settings;
        }

        public void ProcessOrder(Cart cart, ShippingDetails shippingInfo)
        {

        }
    }
}
