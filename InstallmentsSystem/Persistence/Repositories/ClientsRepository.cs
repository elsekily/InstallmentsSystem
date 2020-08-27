﻿using InstallmentsSystem.Core;
using InstallmentsSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstallmentsSystem.Persistence.Repositories
{
    public class ClientsRepository : IClientRepository
    {
        private readonly InstallmentsSystemDbContext context;

        public ClientsRepository(InstallmentsSystemDbContext context)
        {
            this.context = context;
        }
        public void Add(Client client)
        {
            context.Clients.Add(client);
        }

        public async Task<Client> GetClient(int id)
        {
            var client = await context.Clients.Where(c => c.Id == id).SingleOrDefaultAsync();
            context.Entry(client).Collection(c => c.Installments).Load();
            return client;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            return await context.Clients.ToListAsync();
        }

        public void Remove(Client client)
        {
            context.Remove(client);
        }
    }
}
