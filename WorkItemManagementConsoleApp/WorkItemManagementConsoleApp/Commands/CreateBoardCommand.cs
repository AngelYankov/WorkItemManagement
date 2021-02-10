using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementConsoleApp.Commands.Abstract;
using WorkItemManagementConsoleApp.Core;
using WorkItemManagementConsoleApp.Models.Contracts;

namespace WorkItemManagementConsoleApp.Commands
{
    public class CreateBoardCommand : Command
    {
        public CreateBoardCommand(IList<string> commandParameters)
            :base(commandParameters)
        {
        }
        public override string Execute() // createboard board1 team1
        {
            Validator.ValidateParameters(this.CommandParameters, 2);
            string name = this.CommandParameters[0];
            string teamName = this.CommandParameters[1];

            var team = Validator.GetTeam(teamName);
            Validator.BoardExistsInTeam(name, team);

            IBoard board = this.Factory.CreateBoard(name);
            team.AddBoard(board);
            return $"Board: '{name}' was created in team: '{teamName}'";
        }
    }
}
