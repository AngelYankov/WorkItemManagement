using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementConsoleApp.Commands.Abstract;
using WorkItemManagementConsoleApp.Models.Contracts;

namespace WorkItemManagementConsoleApp.Commands
{
    public class CreateMemberCommand : Command
    {
        public CreateMemberCommand(IList<string> commandParameters)
            :base(commandParameters)
        {

        }

        public override string Execute() // createmember member1
        {
            if(CommandParameters.Count != 1)
            {
                throw new ArgumentException("Parameters count is not valid");
            }
            string name = this.CommandParameters[0];
            bool nameExists = this.Database.AllMembers.Any(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (nameExists)
            {
                throw new ArgumentException($"Member: '{name}' already exists.");
            }

            IMember member = this.Factory.CreateMember(name);
            this.Database.AllMembers.Add(member);

            return $"Member: '{name}' created";
        }
    }
}
