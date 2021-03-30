using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalkDeskInterviewApp.Models;

namespace TalkDeskInterviewApp.Data
{
    public class MockCommandRepo : ICommandRepo
    {
        private List<Command> _commands = new List<Command>()
                                            {
                                                new Command(){ Id = 1, HowTo = "command1HowTo", Line = "command1Line", Platform ="command1Platform" },
                                                new Command(){ Id = 2, HowTo = "command2HowTo", Line = "command2Line", Platform ="command2Platform" },
                                                new Command(){ Id = 3, HowTo = "command3HowTo", Line = "command3Line", Platform ="command3Platform" },
                                            };
        public void CreateCommand(Command command)
        {
            command.Id = _commands.Last().Id + 1;
            _commands.Add(command);
        }

        public void DeleteCommand(Command command)
        {
            _commands.Remove(command);
        }

        public Task<Command> GetCommandById(int id)
        {
            return Task.FromResult(_commands.FirstOrDefault(c => c.Id == id));
        }

        public IQueryable<Command> GetAllCommands()
        {
            return _commands.AsQueryable();
        }

        public Task<bool> SaveChanges()
        {
            // do nothing....
            return Task.FromResult(true);
        }

        public void UpdateCommand(Command command)
        {
            _commands[_commands.FindIndex((c) => c.Id == command.Id)] = command;
        }
    }
}
