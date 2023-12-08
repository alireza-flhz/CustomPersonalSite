using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel.DTO.ViewModels;
using DomainModel.Models;

namespace DataAccessServiceContract
{
    public interface ISectionRepository:IBaseRepository<Sections,int>
    {
        Task<RepositoryResult<List<int>>> AddSections(List<int> defaultSectionsId);
        
    }
}