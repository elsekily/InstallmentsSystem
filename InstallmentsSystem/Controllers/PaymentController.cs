using AutoMapper;
using InstallmentsSystem.Core;
using InstallmentsSystem.Entities.Models;
using InstallmentsSystem.Entities.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace InstallmentsSystem.Controllers
{
    [Authorize(Policy = Policies.Moderator)]
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IPaymentRepository repository;
        private readonly IInstallmentRepository installmentRepository;

        public PaymentController(IMapper mapper, IUnitOfWork unitOfWork,
            IPaymentRepository repository, IInstallmentRepository installmentRepository)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.installmentRepository = installmentRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentSaveResource paymentResource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var payment = mapper.Map<PaymentSaveResource, Payment>(paymentResource);
            repository.Add(payment);
            await unitOfWork.CompleteAsync();

            var installment = await installmentRepository.GetInstallment(payment.InstallmentId);
            var result = mapper.Map<Installment, InstallmentResourece>(installment);
            return Created(nameof(CreatePayment), result);
        }

        [Authorize(Policy = Policies.Admin)]
        [HttpDelete("{installmentId}")]
        public async Task<IActionResult> DeleteLastPayment(int installmentId)
        {
            var installment = await installmentRepository.GetInstallment(installmentId);

            if (installment.Payments.Count == 0)
                return NotFound();

            repository.Remove(installment.Payments.Last());
            await unitOfWork.CompleteAsync();

            return Accepted();
        }
    }
}
