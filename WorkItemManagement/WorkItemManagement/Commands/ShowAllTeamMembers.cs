using System.Collections.Generic;
using System.Linq;
using WorkItemManagement.Commands.Abstract;
using WorkItemManagement.Core;

namespace WorkItemManagement.Commands
{
    public class ShowAllTeamMembers : Command
    {
        public ShowAllTeamMembers(IList<string> commandParameters)
            :base(commandParameters)
        {
        }
        public override string Execute() //showteammembers team1
        {
            Validator.ValidateParameters(this.CommandParameters, 1);
            string teamName = this.CommandParameters[0];
            var team = Validator.GetTeam(teamName, Database);

            return  team.Members.Count != 0
                ? string.Join(", ", team.Members.Select(m => m.Name))
                : $"There are no members in team: '{teamName}'.";
        }
    }
}
