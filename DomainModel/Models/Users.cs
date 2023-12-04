using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DomainModel.Models
{
    public class Users : IdentityUser
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
