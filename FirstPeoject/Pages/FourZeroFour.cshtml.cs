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
    public class FourZeroFour : PageModel
    {
        private readonly ILogger<FourZeroFour> _logger;

        public FourZeroFour(ILogger<FourZeroFour> logger)
        {
            _logger = logger;
        }
        private ErrorViewModel _errorModel{get;set;}
        public void OnGet()
        {
        }
    }
}