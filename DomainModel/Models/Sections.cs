using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Sections
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public int DefaultSecctionID { get; set; }
        public virtual DefaultSection defaultSection { get; set; }
        public virtual ICollection<SectionUserLayout> SectionUserLayouts { get; set; }
        public virtual ICollection<SectionsMedia> sectionsMedias { get; set; }
    }
}