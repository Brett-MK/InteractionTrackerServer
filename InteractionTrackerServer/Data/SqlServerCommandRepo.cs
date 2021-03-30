using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InteractionTrackerServer.Models;

namespace InteractionTrackerServer.Data
{
    public class SqlServerCommandRepo : ICommandRepo
    {
        private CommandContext _context;

        public SqlServerCommandRepo(CommandContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentException(nameof(command));
            }

            _context.Commands.Add(command);
        }

        public void DeleteCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentException(nameof(command));
            }

            _context.Commands.Remove(command);
        }

        public IQueryable<Command> GetAllCommands()
        {
            return _context.Commands;
        }

        public async Task<Command> GetCommandById(int id)
        {
            return await _context.Commands.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync()) >= 0;
        }

        public void UpdateCommand(Command command)
        {
            // Do nothing
        }
    }
}
