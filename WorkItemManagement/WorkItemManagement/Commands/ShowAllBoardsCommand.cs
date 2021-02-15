using System.Collections.Generic;
using System.Linq;
using WorkItemManagement.Commands.Abstract;
using WorkItemManagement.Core;

namespace WorkItemManagement.Commands
{
    public class ShowAllBoardsCommand : Command
    {
        public ShowAllBoardsCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }
        public override string Execute() //showallboards team1
        {
            Validator.ValidateParameters(this.CommandParameters, 1);
            string teamName = this.CommandParameters[0];
            var team = Validator.GetTeam(teamName);

            return team.Boards.Count != 0 
                ? string.Join(", ", team.Boards.Select(b => b.Name))
                : $"There are no boards in team: '{teamName}'.";
        }
    }
}
