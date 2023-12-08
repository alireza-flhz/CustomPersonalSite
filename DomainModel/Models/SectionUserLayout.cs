using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class SectionUserLayout
    {
        public int ID { get; set; }
        public UserLayout userLayout { get; set; }
        public int userLayoutID { get; set; }
        public Sections Sections { get; set; }
        public int sectionID { get; set; }
    }
}