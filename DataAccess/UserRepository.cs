using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessServiceContract;
using DomainModel;
using DomainModel.DTO.ViewModels;
using DomainModel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace DataAccess
{
    public class UserRepository : BaseRepository<Users, string>, IUserRepository
    {
        private readonly PersonalContext context;
        private readonly UserManager<Users> userManager;
        private readonly SignInManager<Users> signInManager;

        public UserRepository(PersonalContext context, IHttpContextAccessor _accessor, UserManager<Users> userManager = null) : base(context, _accessor)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<RepositoryResult> Login(string UserName, string Password)
        {
            var ReturnModel = new RepositoryResult();
            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                ReturnModel.IsSuccess = false;
                ReturnModel.Error = "Error in UserName Or Password";
                return ReturnModel;
            }
            var resPass = await userManager.CheckPasswordAsync(user, Password);
            if (!resPass)
            {
                ReturnModel.IsSuccess = false;
                ReturnModel.Error = "Error in UserName Or Password";
                return ReturnModel;
            }
            ReturnModel.IsSuccess = true;
            return ReturnModel;
        }
    }
}