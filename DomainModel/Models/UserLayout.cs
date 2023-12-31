using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class UserLayout
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public virtual Users user { get; set; }
        public int LayoutID { get; set; }
        public virtual Layouts layout { get; set; }
        public string Name { get; set; }
        public ICollection<SectionUserLayout>  sectionUserLayouts{ get; set; }
    }
}