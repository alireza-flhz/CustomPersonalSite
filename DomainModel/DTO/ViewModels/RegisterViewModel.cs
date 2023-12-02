using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel.DTO.ViewModels
{
    public partial class RegisterViewModel
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string rePassword { get; set; }
    }
}