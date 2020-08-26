using AutoMapper;
using InstallmentsSystem.Core;
using InstallmentsSystem.Entities.Models;
using InstallmentsSystem.Entities.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
   
        //[Authorize(Policy = Policies.Moderator)]
        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentSaveResource paymentResource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var payment = mapper.Map<PaymentSaveResource, Payment>(paymentResource);
            repository.Add(payment);
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
