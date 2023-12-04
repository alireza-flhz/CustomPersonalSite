using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel.DTO.ViewModels;
using DomainModel.Models;

namespace DataAccessServiceContract
{
    public interface IUserRepository:IBaseRepository<Users,string>
    {
        Task<RepositoryResult> Login(string UserName,string Password);
    }
}