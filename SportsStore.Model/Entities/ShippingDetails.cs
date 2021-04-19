using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Model.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Пожалуйста укажите имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Пожалуйста укажите адрес")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        [Required(ErrorMessage = "Пожалуйста укажите город")]
        public string City { get; set; }
        public string Zip { get; set; }
        public bool GiftWrap { get; set; }
    }
}
