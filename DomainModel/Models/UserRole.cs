using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class UserRole
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public virtual Users User { get; set; }
        public string RoleID { get; set; }
        public virtual Role Role { get; set; }
    }
}
