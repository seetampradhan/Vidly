using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Custmore
    {
        public int Id { get; set; }

        [Required,StringLength(255)]        
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        public int MembershipTypeId { get; set; }
        public DateTime? Birthdate { get; set; }
    }
}