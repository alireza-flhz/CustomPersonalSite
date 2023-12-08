using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel.DTO.ViewModels;
using DomainModel.Models;

namespace DataAccessServiceContract
{
    public interface IUserLayoutRepository:IBaseRepository<UserLayout,int>
    {
        Task<RepositoryResult> AddDefaultLayout(string UserID);
        Task<RepositoryResult> NewUserLayout(string UserID, List<int> Section, int LayoutID,int? userLayoutID ,string Name);
        
        
    }
}