using AutoMapper;
using InstallmentsSystem.Core;
using Microsoft.AspNetCore.Mvc;

namespace InstallmentsSystem.Controllers
{
    public class InstallmentController : Controller
    {
        private readonly IMapper mapper;
        private readonly IInstallmentRepository repository;

        public InstallmentController(IMapper mapper, IInstallmentRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

    }
}
