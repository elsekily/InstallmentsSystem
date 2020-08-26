using AutoMapper;
using InstallmentsSystem.Core;
using Microsoft.AspNetCore.Mvc;

namespace InstallmentsSystem.Controllers
{
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IPaymentRepository repository;

        public PaymentController(IMapper mapper, IUnitOfWork unitOfWork,
            IPaymentRepository repository)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.repository = repository;
        }

    }
}
