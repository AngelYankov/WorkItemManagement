using System.Collections.Generic;
using System.Linq;
using WorkItemManagement.Commands.Abstract;
using WorkItemManagement.Core;

namespace WorkItemManagement.Commands
{
    public class ShowAllMembersCommand : Command
    {
        public ShowAllMembersCommand(IList<string> commandParameters)
            :base(commandParameters)
        {
        }
        public override string Execute()
        {
            Validator.ValidateParameters(this.CommandParameters, 0);
            return Database.GetAllMembers().Count != 0 
                ? string.Join(", ", Database.GetAllMembers().Select(m => m.Name)) 
                : "There are no members.";
        }
    }
}
