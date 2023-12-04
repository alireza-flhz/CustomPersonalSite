using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessServiceContract;
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
        public void OnPost()
        {
        }
    }
}