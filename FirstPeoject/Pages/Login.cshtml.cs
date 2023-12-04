using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessServiceContract;
using DomainModel.DTO.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FirstPeoject.Pages
{
    public class Login : PageModel
    {
        private readonly ILogger<Login> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;

        public Login(ILogger<Login> logger, IUserRepository userRepository = null, IRoleRepository roleRepository = null, IUserRoleRepository userRoleRepository = null)
        {
            _logger = logger;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
        }

        public void OnGet()
        {

        }
        [BindProperty]
        public LoginViewModel LoginModel { get; set; }
        public async void OnPost()
        {
            var ErrorModel = new ErrorViewModel();
            try
            {
                var resLogin = await _userRepository.Login(LoginModel.UserName, LoginModel.Password);
                if (!resLogin.IsSuccess)
                {
                    ErrorModel.Title = resLogin.Error;
                    RedirectToPage("/FourZeroFour", ErrorModel);
                }
                ErrorModel.Title = resLogin.Error;
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