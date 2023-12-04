using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel.DTO.ViewModels
{
    public partial class ErrorViewModel
    {
        public string Title { get; set; }
        public long DataTime { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        
    }
}