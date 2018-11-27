using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class NewCustomerViewModel
    {
        [Display(Name = "Membership Type")]
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public Custmore Custmore { get; set; }
    }
}