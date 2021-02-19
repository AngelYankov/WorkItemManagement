using System.Collections.Generic;
using WorkItemManagement.Commands.Abstract;
using WorkItemManagement.Core;
using WorkItemManagement.Core.Contracts;

namespace WorkItemManagement.Commands
{
    class ShowBoardActivityCommand : Command
    {
        public ShowBoardActivityCommand(IList<string> commandParameters, IDatabase database, IFactory factory)
            : base(commandParameters, database, factory)
        {
        }

        public override string Execute() //showboardactivity board1 team1
        {
            var validator = new Validator(Database);
            validator.ValidateParameters(this.CommandParameters, 2);
            string boardName = this.CommandParameters[0];
            string teamName = this.CommandParameters[1];

            var team = Database.GetTeam(teamName);
            var board = Database.GetBoard(boardName, team);

            return string.Join("; ", board.ActivityHistory);
        }
    }
}
