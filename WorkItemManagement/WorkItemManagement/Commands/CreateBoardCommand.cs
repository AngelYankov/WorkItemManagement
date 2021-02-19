using System.Collections.Generic;
using WorkItemManagement.Commands.Abstract;
using WorkItemManagement.Core;
using WorkItemManagement.Models.Contracts;

namespace WorkItemManagement.Commands
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

            var team = Validator.GetTeam(teamName, Database);
            Validator.BoardExistsInTeam(name, team);

            IBoard board = this.Factory.CreateBoard(name);
            team.AddBoard(board);
            return $"Created board: '{name}' in team: '{teamName}'";
        }
    }
}
