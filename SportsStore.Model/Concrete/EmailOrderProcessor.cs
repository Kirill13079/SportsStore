using SportsStore.Model.Abstract;
using SportsStore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Model.Concrete
{
    public class SettingsUser
    {
    }
    public class EmailOrderProcessor : IOrderProcessor
    {
        private SettingsUser emailSettings;
        public EmailOrderProcessor(SettingsUser settings)
        {
            emailSettings = settings;
        }
        public void ProcessOrder(Cart cart, ShippingDetails shippingInfo)
        {
            //ваш код действия
        }
    }
}
