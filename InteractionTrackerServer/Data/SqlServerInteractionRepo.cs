using InteractionTrackerServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionTrackerServer.Data
{
    public class SqlServerInteractionRepo : IInteractionRepo
    {
        private readonly InteractionContext _context;

        public SqlServerInteractionRepo(InteractionContext context)
        {
            _context = context;
        }

        public void CreateInteraction(Interaction interaction)
        {
            if (interaction == null)
            {
                throw new ArgumentException(nameof(interaction));
            }

            _context.Interactions.Add(interaction);
        }

        public IQueryable<Interaction> GetAllInteractions()
        {
            return _context.Interactions
                .Include(i => i.CallData)
                .Include(i => i.AgentData)
                .Include(i => i.Duration)
                .Include(i => i.WaitingTime);
        }

        public async Task<Interaction> GetInteractionById(string id)
        {
            return await _context.Interactions.Include(i => i.CallData)
                .Include(i => i.AgentData)
                .Include(i => i.Duration)
                .Include(i => i.WaitingTime)
                .FirstOrDefaultAsync(i => i.CallId == id);
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
