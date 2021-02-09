using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementConsoleApp.Commands.Abstract;
using WorkItemManagementConsoleApp.Models.Contracts;
using WorkItemManagementConsoleApp.Models.WorkItems;

namespace WorkItemManagementConsoleApp.Commands
{
    public class CreateBugCommand : Command
    {
        public CreateBugCommand(IList<string> commandParameters)
            :base(commandParameters)
        {

        }

        public override string Execute() // createbug board1 team1 
        {
            if(this.CommandParameters.Count < 9)
            {
                throw new ArgumentException("Parameters count is not valid.");
            }

            string teamName = this.CommandParameters[0];
            string boardName = this.CommandParameters[1];
            string id = this.CommandParameters[2];
            string title = this.CommandParameters[3];
            string description = this.CommandParameters[4];
            string priority = this.CommandParameters[5];
            string severity = this.CommandParameters[6];
            string status = this.CommandParameters[7];
            List<string> steps = this.CommandParameters[8].Split(",").ToList();

            var existingTeam = this.Database.AllTeams.FirstOrDefault(t => t.Name.Equals(teamName, StringComparison.OrdinalIgnoreCase));
            if(existingTeam == null)
            {
                throw new ArgumentException($"Team: '{teamName}' does not exist.");
            }

            var existingBoard = existingTeam.Boards.FirstOrDefault(b => b.Name.Equals(boardName, StringComparison.OrdinalIgnoreCase));
            if(existingBoard == null)
            {
                throw new ArgumentException($"Board: '{boardName}' does not exist.");
            }

            IWorkItem bug = this.Factory.CreateBug(id, title, description, priority, severity, status, steps);
            existingBoard.AddWorkItem(bug);
            this.Database.AllWorkItems.Add(bug);

            return $"Bug: '{title}' with id: '{id}' added to board: '{boardName}' in team: '{teamName}'";

        }
    }
}
