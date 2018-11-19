using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

using MvcMusicStore.Infrastructure;
using System.ComponentModel;
using System.Web.Mvc;

namespace MvcMusicStore.Models
{
    [Bind(Exclude="OrderId")]
    public class Order
    {
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }

        [ScaffoldColumn(false)]
        public DateTime OrderDate { get; set; }

        [ScaffoldColumn(false)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Your {0} is required")]
        [StringLength(160, MinimumLength =3)]
        [Display(Name ="First Name",Order =15000)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Your {0} is required")]
        [StringLength(160            )]
        [MaxWords(10)]
        [Display(Name ="Last Name", Order =15001)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Your {0} is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Your {0} is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Your {0} is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "Your {0} is required")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Your {0} is required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Your {0} is required")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Your {0} is required")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage ="Does not look like a valid email address")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public decimal Total { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}