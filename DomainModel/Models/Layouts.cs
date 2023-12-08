using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Layouts
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool Default { get; set; }
        public int MaxCount_Sections { get; set; }
        public ICollection<UserLayout> _userLayout { get; set; }
    }
}