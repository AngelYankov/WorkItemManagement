using System.Collections.Generic;
using System.Linq;
using WorkItemManagement.Commands.Abstract;
using WorkItemManagement.Core;
using WorkItemManagement.Core.Contracts;

namespace WorkItemManagement.Commands
{
    public class ShowAllMembersCommand : Command
    {
        public ShowAllMembersCommand(IList<string> commandParameters, IDatabase database, IFactory factory)
            : base(commandParameters, database, factory)
        {
        }
        public override string Execute()
        {
            var validator = new Validator(Database);

            validator.ValidateParameters(this.CommandParameters, 0);
            return Database.GetAllMembers().Count != 0 
                ? string.Join(", ", Database.GetAllMembers().Select(m => m.Name)) 
                : "There are no members.";
        }
    }
}
