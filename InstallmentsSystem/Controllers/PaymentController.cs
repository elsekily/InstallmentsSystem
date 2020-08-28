using AutoMapper;
using InstallmentsSystem.Core;
using InstallmentsSystem.Entities.Models;
using InstallmentsSystem.Entities.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InstallmentsSystem.Controllers
{
    //[Authorize(Policy = Policies.Moderator)]
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

        [HttpPost]
        public async Task<IActionResult> CreateInstallment([FromBody] PaymentSaveResource paymentResource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var payment = mapper.Map<PaymentSaveResource, Payment>(paymentResource);
            repository.Add(payment);
            await unitOfWork.CompleteAsync();

            payment = await repository.GetPayment(payment.Id);
            var result = mapper.Map<Payment, PaymentResource>(payment);
            return Created(nameof(UpdatePayment), result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment(int id,
            [FromBody] PaymentSaveResource paymentResource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var payment = await repository.GetPayment(id);
            mapper.Map<PaymentSaveResource, Payment>(paymentResource, payment);

            await unitOfWork.CompleteAsync();

            //payment = await repository.GetInstallment(installment.Id);
            //var result = mapper.Map<Installment, InstallmentResoureceWithPayments>(installment);
            return Accepted();// result);
        }

        [Authorize(Policy = Policies.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var payment = await repository.GetPayment(id);

            if (payment == null)
                return NotFound();

            repository.Remove(payment);
            await unitOfWork.CompleteAsync();

            return Accepted();
        }
    }
}
