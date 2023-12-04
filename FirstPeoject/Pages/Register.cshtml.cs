using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessServiceContract;
using DomainModel.DTO.ViewModels;
using DomainModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FirstPeoject.Pages
{
    public class Register : PageModel
    {
        private readonly ILogger<Register> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;

        public Register(ILogger<Register> logger, IUserRepository userRepository = null, IUserRoleRepository userRoleRepository = null, IRoleRepository roleRepository = null)
        {
            _logger = logger;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
        }

        public void OnGet() { }

        [BindProperty]
        public RegisterViewModel RegisterModel { get; set; }


        public async void OnPost()
        {
            var ErrorModel = new ErrorViewModel();
            try
            {
                if (!ModelState.IsValid)
                    RedirectToPage("/FourZeroFour");
                var user = new Users()
                {
                    UserName = RegisterModel.Name,
                    Email = RegisterModel.Mail,
                    Name = RegisterModel.Name,
                    Family = RegisterModel.Family
                };
                var resAdd = await _userRepository.AddAsync(user);
                if (!resAdd.Success)
                {
                    ErrorModel.Title = "Error in Add User to DataBase.";
                    RedirectToPage("/FourZeroFour", ErrorModel);
                }
                resAdd = await _userRepository.SaveAsync();
                if (!resAdd.Success)
                {
                    ErrorModel.Title = "Error in Save DataBase.";
                    RedirectToPage("/FourZeroFour", ErrorModel);
                }
                
                var GetRole = await _roleRepository.GetAllAsQueryable().SingleOrDefaultAsync(x => x.Name == "User");
                if (GetRole == null)
                {
                    ErrorModel.Title = "Error in Get Role.";
                    RedirectToPage("/FourZeroFour", ErrorModel);
                }
                resAdd = await _userRoleRepository.AddAsync(new UserRole()
                {
                    RoleID = GetRole.Id,
                    UserID = user.Id
                });
                if (!resAdd.Success)
                {
                    ErrorModel.Title = "Error in Add UserRole.";
                    RedirectToPage("/FourZeroFour", ErrorModel);
                }
                resAdd = await _userRepository.SaveAsync();
                if (!resAdd.Success)
                {
                    ErrorModel.Title = "Error in Save DataBase.";
                    RedirectToPage("/FourZeroFour", ErrorModel);
                }
                ErrorModel.Title = "Success";
                RedirectToPage("/Index", ErrorModel);

            }
            catch (System.Exception ex)
            {
                ErrorModel.Title = ex.Message;
                RedirectToPage("/FourZeroFour", ErrorModel);
                throw;
            }
        }
    }
}
