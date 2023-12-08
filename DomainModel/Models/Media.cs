using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Media
    {
        public int ID { get; set; }
        public string URI { get; set; }
        public string Extention { get; set; }
        public Type Type { get; set; }
        public MediaCategory TargetCategory { get; set; }
        public string Hash { get; set; }
        public bool IsPublic { get; set; }
        public bool IsVerifed { get; set; } = false;
        public string UserID { get; set; }
        public int? TargetID { get; set; }
        public TableName Target { get; set; }

    }
    public enum Type
    {
        Image = 1,
        Voice = 2,
        Video = 3,
        PDF = 4
    }

    public enum MediaCategory
    {

    }
    public enum TableName
    {
        section=1,
        user=2,
        
    }

}