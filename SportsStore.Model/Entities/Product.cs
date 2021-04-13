using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SportsStore.Model.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Пожалуйста введите наименование продукта")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Пожалуйста введите описание продукта")]
        public string Description { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста введите цену > 0")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Пожалуйста укажите категорию")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Пожалуйста укажите размер")]
        public string Size { get; set; }
        [Required(ErrorMessage = "Пожалуйста укажите фирму")]
        public string Firma { get; set; }
        public  IEnumerable<string> SizeMass 
        {
            get
            {
                var s = Size.Split(' ');
                foreach (var size in s)
                    yield return size.ToString();
            }
        }

        public byte[] ImageData { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }


    }

}
