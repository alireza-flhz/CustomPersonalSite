using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel.Models;

namespace DataAccessServiceContract
{
    public interface IRoleRepository:IBaseRepository<Role,string>
    {
        
    }
}