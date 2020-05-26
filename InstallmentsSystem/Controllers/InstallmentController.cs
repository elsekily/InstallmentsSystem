using AutoMapper;
using InstallmentsSystem.Core;
using InstallmentsSystem.Entities.Models;
using InstallmentsSystem.Entities.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace InstallmentsSystem.Controllers
{
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


        //[Authorize(Policy = Policies.Moderator)]
        [HttpPost]
        public async Task<IActionResult> CreateInstallment([FromBody] InstallmentSaveResource installmentResource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var installment = mapper.Map<InstallmentSaveResource, Installment>(installmentResource);
            repository.Add(installment);
            await unitOfWork.CompleteAsync();
            /*
            author.User = userManager.GetUserAsync(HttpContext.User).Result;
            

            author = await repository.GetAuthor(author.ID);
            var result = mapper.Map<Author, AuthorWithBooksResource>(author);
            //return Created(nameof(GetAuthor), result);*/
            return Ok();
        }
    }
}
