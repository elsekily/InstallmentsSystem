using AutoMapper;
using InstallmentsSystem.Core;
using InstallmentsSystem.Entities.Models;
using InstallmentsSystem.Entities.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstallmentsSystem.Controllers
{
    //[Authorize(Policy = Policies.Moderator)]
    [Route("api/[controller]")]
    public class InstallmentController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IInstallmentRepository repository;

        public InstallmentController(IMapper mapper, IUnitOfWork unitOfWork,
            IInstallmentRepository repository)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.repository = repository;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInstallment(int id)
        {
            var installment = await repository.GetInstallment(id);

            if (installment == null)
                return NotFound();
            return Ok(mapper.Map<Installment, InstallmentResoureceWithPayments>(installment));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetInstallments()
        {
            var installments = await repository.GetInstallments();
            return Ok(mapper.Map<IEnumerable<Installment>, IEnumerable<InstallmentResourece>>(installments));
        }

        [HttpGet("client/{clientId}")]
        public async Task<IActionResult> GetClientInstallments(int clientId)
        {
            var installments = await repository.GetClientInstallments(clientId);
            return Ok(mapper.Map<IEnumerable<Installment>, IEnumerable<InstallmentResourece>>(installments));
        }

        [HttpPost]
        public async Task<IActionResult> CreateInstallment([FromBody] InstallmentSaveResource installmentResource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var installment = mapper.Map<InstallmentSaveResource, Installment>(installmentResource);
            repository.Add(installment);
            await unitOfWork.CompleteAsync();

            installment = await repository.GetInstallment(installment.Id);
            var result = mapper.Map<Installment, InstallmentResourece>(installment);
            return Created(nameof(GetInstallment), result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInstallment(int id, 
            [FromBody] InstallmentSaveResource InstallmentResource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var installment = await repository.GetInstallment(id);
            mapper.Map<InstallmentSaveResource, Installment>(InstallmentResource, installment);

            await unitOfWork.CompleteAsync();

            installment = await repository.GetInstallment(installment.Id);
            var result = mapper.Map<Installment, InstallmentResoureceWithPayments>(installment);
            return Accepted(result);
        }

        [HttpPut("nextpayment/{id}")]
        public async Task<IActionResult> UpdateNextPayemtofInstallment(int id,
            [FromBody] IdDatePair idDatePair)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var installment = await repository.GetInstallment(id);
            installment.NextPayment = idDatePair.Date;

            await unitOfWork.CompleteAsync();

            installment = await repository.GetInstallment(installment.Id);
            var result = mapper.Map<Installment, InstallmentResoureceWithPayments>(installment);
            return Accepted(result);
        }

        //[Authorize(Policy = Policies.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstallment(int id)
        {
                var installment = await repository.GetInstallment(id);

                if (installment == null)
                    return NotFound();

                repository.Remove(installment);
                await unitOfWork.CompleteAsync();

            return Accepted();
        }
    }
}
