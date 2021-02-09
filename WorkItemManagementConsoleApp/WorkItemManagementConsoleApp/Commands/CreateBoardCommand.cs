using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementConsoleApp.Commands.Abstract;
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
            if(this.CommandParameters.Count != 2)
            {
                throw new ArgumentException("Parameters count is not valid");
            }

            string name = this.CommandParameters[0];
            string teamName = this.CommandParameters[1];

            var team = this.Database.AllTeams.FirstOrDefault(t => t.Name.Equals(teamName, StringComparison.OrdinalIgnoreCase));
            if (team == null)
            {
                throw new ArgumentException($"Team: '{teamName}' does not exist.");
            }

            var existingBoard = team.Boards.FirstOrDefault(b => b.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if(existingBoard != null)
            {
                throw new ArgumentException($"Board: '{name}' already exists in team: '{teamName}'");
            }

            IBoard board = this.Factory.CreateBoard(name);
            team.AddBoard(board);

            return $"Board: '{name}' was created in team: '{teamName}'";
        }
    }
}
