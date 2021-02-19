using System.Collections.Generic;
using WorkItemManagement.Commands.Abstract;
using WorkItemManagement.Core;

namespace WorkItemManagement.Commands
{
    class ShowBoardActivityCommand : Command
    {
        public ShowBoardActivityCommand(IList<string> commandParameters)
            :base(commandParameters)
        {
        }

        public override string Execute() //showboardactivity board1 team1
        {
            Validator.ValidateParameters(this.CommandParameters, 2);
            string boardName = this.CommandParameters[0];
            string teamName = this.CommandParameters[1];

            var team = Validator.GetTeam(teamName, Database);
            var board = Validator.GetBoard(boardName, team);

            return string.Join("; ", board.ActivityHistory);
        }
    }
}
