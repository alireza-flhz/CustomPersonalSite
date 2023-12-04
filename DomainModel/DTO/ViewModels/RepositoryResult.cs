using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel.DTO.ViewModels
{
    public partial class RepositoryResult<T>
    {
        public bool IsSuccess { get; set; }
        public T Model { get; set; }
        public string Error { get; set; }

    }
    public partial class RepositoryResult
    {
        public bool IsSuccess { get; set; }
        public string Error { get; set; }

    }
}