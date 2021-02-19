using System.Collections.Generic;
using WorkItemManagement.Commands.Abstract;
using WorkItemManagement.Core;
using WorkItemManagement.Core.Contracts;
using WorkItemManagement.Models.Contracts;

namespace WorkItemManagement.Commands
{
    public class CreateBoardCommand : Command
    {
        public CreateBoardCommand(IList<string> commandParameters, IDatabase database, IFactory factory)
            : base(commandParameters, database, factory)
        {
        }
        public override string Execute() // createboard board1 team1
        {
            var validator = new Validator(Database);

            validator.ValidateParameters(this.CommandParameters, 2);
            string name = this.CommandParameters[0];
            string teamName = this.CommandParameters[1];

            var team = Database.GetTeam(teamName);
            validator.BoardExistsInTeam(name, team);

            IBoard board = this.Factory.CreateBoard(name);
            team.AddBoard(board);
            return $"Created board: '{name}' in team: '{teamName}'";
        }
    }
}
