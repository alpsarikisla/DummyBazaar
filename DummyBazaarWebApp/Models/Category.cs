using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DummyBazaarWebApp.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Display(Name = "Kategori Adı")]
        [Required(ErrorMessage = "Alan Boş Bırakılamaz")]
        [StringLength(maximumLength:50, ErrorMessage = "Bu alan en fazla 50 karakter olmalıdır")]
        public string Name { get; set; }

        [Display(Name = "Açıklama")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}