using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace truyum_WebAPIPracticeCheck.Models
{
    public class MenuItem
    {
        [Key]
        [Required(ErrorMessage = "Enter Id")]
        public int MenuItemId { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Price")]
        public double price { get; set; }

        public bool Active { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "DateOfLaunch")]
        public DateTime DateOfLaunch { get; set; }

        [Display(Name = "FreeDelivery")]
        public bool freedelivery { get; set; }

    }
}
