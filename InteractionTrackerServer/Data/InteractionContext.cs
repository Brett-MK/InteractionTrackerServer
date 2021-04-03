using InteractionTrackerServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionTrackerServer.Data
{
    public class InteractionContext : DbContext
    {
        public InteractionContext(DbContextOptions<InteractionContext> options) : base(options)
        {
        }

        public DbSet<Interaction> Interactions { get; set; }
    }
}
