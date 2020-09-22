using AutoMapper;
using InstallmentsSystem.Core;
using InstallmentsSystem.Entities.Models;
using InstallmentsSystem.Entities.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstallmentsSystem.Controllers
{
    //[Authorize(Policy = Policies.Moderator)]
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
            return Ok(mapper.Map<Client, ClientResourceWithInstallments>(client));
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var clients = await repository.GetClients();
            return Ok(mapper.Map<IEnumerable<Client>, IEnumerable<ClientResource>>(clients));
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] ClientSaveResource clientResource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var client = mapper.Map <ClientSaveResource, Client>(clientResource);
            repository.Add(client);

            await unitOfWork.CompleteAsync();

            client = await repository.GetClient(client.Id);
            var result = mapper.Map<Client, ClientResource>(client);
            return Created(nameof(GetClient), result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] ClientSaveResource clientResource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var client = await repository.GetClient(id);
            mapper.Map<ClientSaveResource, Client>(clientResource, client);

            await unitOfWork.CompleteAsync();

            client = await repository.GetClient(client.Id);
            var result = mapper.Map<Client, ClientResource>(client);
            return Accepted(result);
        }

        [Authorize(Policy = Policies.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await repository.GetClient(id);

            if (client == null)
                return NotFound();

            repository.Remove(client);
            await unitOfWork.CompleteAsync();

            return Accepted();
        }
    }
}

