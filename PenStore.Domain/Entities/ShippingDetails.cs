using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace PenStore.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Укажите Ваше Имя")]
        public string Name { get; set; }

   

        [Required(ErrorMessage = "Вставьте адрес доставки")]
        [Display(Name = "Адрес")]
        public string Line1 { get; set; }

        //[Display(Name = "Адрес 2")]
        //public string Line2 { get; set; }

        [Required(ErrorMessage = "Укажите город")]
        [Display(Name = "Город")]
        public string City { get; set; }

        [Required(ErrorMessage = "Укажите страну")]
        [Display(Name = "Страна")]
        public string Country { get; set; }

       

        //[Display(Name = "Третий адрес")]
        //public string Line3 { get; set; }

        
        public bool GiftWrap { get; set; }
    }
}