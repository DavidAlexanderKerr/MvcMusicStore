using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

using MvcMusicStore.Infrastructure;
using System.ComponentModel;

namespace MvcMusicStore.Models
{
    public class Order
    {
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }
        [ScaffoldColumn(false)]
        public DateTime OrderDate { get; set; }

        [ScaffoldColumn(false)]
        public string Username { get; set; }

        [Required]
        [StringLength(160, MinimumLength =3)]
        [Display(Name ="First Name",Order =15000)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(160,
            ErrorMessage ="Your {0} is required")]
        [MaxWords(10)]
        [Display(Name ="Last Name", Order =15001)]
        public string LastName { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage ="Does not look like a valid email address")]
        public string Email { get; set; }

        [ReadOnly(true)]
        public decimal Total { get; set; }
        //public List<OrderDetail> OrderDetails { get; set; }
    }
}