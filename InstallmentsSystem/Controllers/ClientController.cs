using AutoMapper;
using InstallmentsSystem.Core;
using InstallmentsSystem.Entities.Models;
using InstallmentsSystem.Entities.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstallmentsSystem.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IClientRepository repository;

        public ClientController(IMapper mapper, IUnitOfWork unitOfWork,
            IClientRepository repository)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.repository = repository;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var client = await repository.GetClient(id);
            return Ok(mapper.Map<Client, ClientResource>(client));
        }
        [HttpGet("create")]
        public ActionResult Create()
        {
            return View("ClientForm", new ClientResource());
        }

        //[Authorize(Policy = Policies.Moderator)]
        [HttpPost]
        public async Task<IActionResult> CreateClient(ClientSaveResource clientResource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var client = mapper.Map <ClientSaveResource, Client>(clientResource);
            repository.Add(client);

            await unitOfWork.CompleteAsync();

            return RedirectToAction("Index");
        }
        /*
        [Authorize(Policy = Policies.Moderator)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] AuthorSaveResource authorResource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var author = await repository.GetAuthor(id);
            mapper.Map<AuthorSaveResource, Author>(authorResource, author);

            await unitOfWork.CompleteAsync();

            author = await repository.GetAuthor(author.ID);
            var result = mapper.Map<Author, AuthorWithBooksResource>(author);
            return Accepted(result);
        }
        [Authorize(Policy = Policies.Moderator)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await repository.GetAuthor(id);

            if (author == null)
                return NotFound();

            repository.Remove(author);
            await unitOfWork.CompleteAsync();

            return Accepted();
        }*/
    }
}

