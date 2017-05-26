using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FLLB.Models
{
    public class UnsubscribeVM
    {
        [Required]
        public int ProId { get; set; }
        [Required]
        public int UnsubscriptionReasonId { get; set; }
        public SelectListItem[] AvailablesReasons { get; set; }
        public DateTime UnsubscribeOn { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email.")]
        [Required(ErrorMessage = "The Email is required")]
        public string EmailPro { get; set; }

    }
}