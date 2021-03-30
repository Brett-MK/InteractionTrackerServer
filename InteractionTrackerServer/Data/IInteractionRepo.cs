using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InteractionTrackerServer.Models;

namespace InteractionTrackerServer.Data
{
    public interface IInteractionRepo
    {
        IQueryable<Interaction> GetAllInteractions();
        Task<Interaction> GetInteractionById(string id);
        void CreateInteraction(Interaction interaction);
        Task<bool> SaveChanges();
    }
}
