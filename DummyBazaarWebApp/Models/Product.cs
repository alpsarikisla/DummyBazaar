using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace DummyBazaarWebApp.Models
{
    public class Product
    {
        public int ID { get; set; }

        public int Category_ID { get; set; }

        [ForeignKey("Category_ID")]
        public virtual Category Category { get; set; }

        [Display(Name = "Ürün Adı")]
        [Required(ErrorMessage = "Alan Boş Bırakılamaz")]
        [StringLength(maximumLength: 75, ErrorMessage = "Bu alan en fazla 75 karakter olmalıdır")]
        public string Name { get; set; }

        [Display(Name = "Ürün Açıklama")]
        [Required(ErrorMessage = "Alan Boş Bırakılamaz")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Fiyat")]
        [Required(ErrorMessage = "Alan Boş Bırakılamaz")]
        public decimal Price { get; set; }

        [Display(Name = "Icon")]
        [StringLength(maximumLength: 150)]
        public string IconPath { get; set; }

        [Display(Name = "Resim")]
        [StringLength(maximumLength: 150)]
        public string ImagePath { get; set; }

        public bool IsActive { get; set; }

    }
}