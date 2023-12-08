using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class SectionsMedia
    {
        public int ID { get; set; }
        public int MediaID { get; set; }
        public Media media { get; set; }
        public int SectionID { get; set; }
        public Sections section { get; set; }
    }
}