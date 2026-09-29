using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace OnlineVoting.Domain.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public string?  FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }

        public string? Address { get; set; }
        public bool? HasVoted { get; set; }
        public bool IsAuthorized { get; set; }

    }
}
