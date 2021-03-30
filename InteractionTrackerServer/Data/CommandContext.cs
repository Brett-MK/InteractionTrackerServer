using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalkDeskInterviewApp.Models;

namespace TalkDeskInterviewApp.Data
{
    public class CommandContext : DbContext
    {
        public CommandContext(DbContextOptions<CommandContext> opts) : base(opts)
        {
        }

        public DbSet<Command> Commands { get; set; }
    }
}
