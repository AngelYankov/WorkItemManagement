using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementConsoleApp.Commands.Abstract;
using WorkItemManagementConsoleApp.Core;
using WorkItemManagementConsoleApp.Models.WorkItems;

namespace WorkItemManagementConsoleApp.Commands
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

            var team = Validator.GetTeam(teamName);
            var board = Validator.GetBoard(boardName, team);

            return string.Join("; ", board.ActivityHistory);
        }
    }
}
