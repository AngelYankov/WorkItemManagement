using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagement.Commands.Abstract;
using WorkItemManagement.Core;

namespace WorkItemManagement.Commands
{
    public class ShowTeamActivityCommand : Command
    {
        public ShowTeamActivityCommand(IList<string> commandParameters)
            :base(commandParameters)
        {
        }
        public override string Execute() //showteamactivity team1
        {
            Validator.ValidateParameters(this.CommandParameters, 1);
            string teamName = this.CommandParameters[0];
            var team = Database.GetTeam(teamName);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Team: '{teamName}' - Boards activity: ");
            team.Boards.Select(b => sb.AppendLine(string.Join("; ", b.ActivityHistory)));
            sb.AppendLine($"Team: '{teamName}' - Members activity: ");
            team.Members.Select(b => sb.AppendLine(string.Join("; ", b.ActivityHistory)));
            return sb.ToString();
        }
    }
}
