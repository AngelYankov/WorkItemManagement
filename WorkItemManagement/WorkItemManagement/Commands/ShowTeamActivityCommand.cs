using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagement.Commands.Abstract;
using WorkItemManagement.Core;
using WorkItemManagement.Core.Contracts;

namespace WorkItemManagement.Commands
{
    public class ShowTeamActivityCommand : Command
    {
        public ShowTeamActivityCommand(IList<string> commandParameters, IDatabase database, IFactory factory)
            : base(commandParameters, database, factory)
        {
        }
        public override string Execute() //showteamactivity team1
        {
            var validator = new Validator(Database);
            validator.ValidateParameters(this.CommandParameters, 1);
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
