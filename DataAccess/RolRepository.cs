using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessServiceContract;
using DomainModel;
using DomainModel.Models;
using Microsoft.AspNetCore.Http;

namespace DataAccess
{
    public class RolRepository : BaseRepository<Role, string>, IRoleRepository
    {
        public RolRepository(PersonalContext context, IHttpContextAccessor _accessor) : base(context, _accessor)
        {
        }
    }
}