using System.Collections.Generic;
using System.Linq;
using WorkItemManagement.Commands.Abstract;
using WorkItemManagement.Core;
using WorkItemManagement.Core.Contracts;

namespace WorkItemManagement.Commands
{
    public class ShowAllBoardsCommand : Command
    {
        public ShowAllBoardsCommand(IList<string> commandParameters, IDatabase database, IFactory factory)
            : base(commandParameters, database, factory)
        {
        }
        public override string Execute() //showallboards team1
        {
            var validator = new Validator(Database);

            validator.ValidateParameters(this.CommandParameters, 1);
            string teamName = this.CommandParameters[0];
            var team = Database.GetTeam(teamName);

            return team.Boards.Count != 0 
                ? string.Join(", ", team.Boards.Select(b => b.Name))
                : $"There are no boards in team: '{teamName}'.";
        }
    }
}
