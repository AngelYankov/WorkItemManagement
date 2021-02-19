using System.Collections.Generic;
using System.Linq;
using WorkItemManagement.Commands.Abstract;
using WorkItemManagement.Core;

namespace WorkItemManagement.Commands
{
    public class ShowAllTeamsCommand : Command
    {
        public ShowAllTeamsCommand(IList<string> commandParameters)
            :base(commandParameters)
        {
        }
        public override string Execute()
        {
            Validator.ValidateParameters(this.CommandParameters, 0);
            return Validator.GetAllTeams(Database).Count != 0
                ? string.Join(", ", Validator.GetAllTeams(Database).Select(t => t.Name))
                : "There are no teams.";
        }
    }
}
