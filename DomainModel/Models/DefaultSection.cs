using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class DefaultSection
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Sections> Sections { get; set; }
    }
}