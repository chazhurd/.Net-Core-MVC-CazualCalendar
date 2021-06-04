using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ItemModel
    {
        [Required(ErrorMessage = "You need to fill this in")]
        public string ItemId { get; set; }
        [Required(ErrorMessage = "You need to fill this in")]
        [Display(Name = "Item")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "You need to fill this in")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "You need to fill this in")]
        [Display(Name = "Photo")]
        public string ImgUrl { get; set; }
    }
}