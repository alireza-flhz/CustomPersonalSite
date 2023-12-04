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
    public class UserRepository : BaseRepository<Users, string>, IUserRepository
    {
        private readonly PersonalContext context;
        public UserRepository(PersonalContext context, IHttpContextAccessor _accessor) : base(context, _accessor)
        {
            this.context=context;
        }
    }
}