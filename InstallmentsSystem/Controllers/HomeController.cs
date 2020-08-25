using System.Diagnostics;
using AutoMapper;
using InstallmentsSystem.Core;
using InstallmentsSystem.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstallmentsSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper mapper;
        private readonly IInstallmentRepository repository;

        public HomeController(ILogger<HomeController> logger, IMapper mapper, 
            IInstallmentRepository repository)
        {
            _logger = logger;
            this.mapper = mapper;
            this.repository = repository;
        }

        public IActionResult Index()
        {
            var lateInstallments = repository.GetLateInstallments();
            return View(lateInstallments);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
