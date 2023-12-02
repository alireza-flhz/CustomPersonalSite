using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel.DTO.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FirstPeoject.Pages
{
    public class Register : PageModel
    {
        private readonly ILogger<Register> _logger;

        public Register(ILogger<Register> logger)
        {
            _logger = logger;
        }

        public void OnGet() { }

        [BindProperty]
        public RegisterViewModel RegisterModel { get; set; }

        public void OnPost()
        { 

        }
    }
}
