using SportsStore.Model.Entities;
using System.Collections.Generic;

namespace SportsStore.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public string CurrentCategory { get; set; }

        public string Search { get; set; }
    }
}