using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementConsoleApp.Commands.Abstract;
using WorkItemManagementConsoleApp.Core;
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
        public override string Execute() // createbug board1 team1 id, title, priority, severity, status, steps, description
        {
            Validator.ValidateParamsIfLessThan(this.CommandParameters, 9);

            string teamName = this.CommandParameters[0];
            string boardName = this.CommandParameters[1];
            string id = this.CommandParameters[2];
            string title = this.CommandParameters[3];
            string priority = this.CommandParameters[4];
            string severity = this.CommandParameters[5];
            string status = this.CommandParameters[6];
            List<string> steps = this.CommandParameters[7].Split("-").ToList(); //mycomputer-controlpanel-dates-setup
            StringBuilder sb = new StringBuilder();
            for (int i = 8; i < this.CommandParameters.Count; i++)
            {
                sb.Append(this.CommandParameters[i]+" ");
            }
            string description = sb.ToString().Trim();

            var existingTeam = Validator.GetTeam(teamName);
            var existingBoard = Validator.GetBoard(boardName, existingTeam);
            
            var bug = this.Factory.CreateBug(id, title, priority, severity, status, steps, description);
            existingBoard.AddWorkItem(bug);
            this.Database.AllWorkItems.Add(bug);

            return $"Bug: '{title}' with id: '{id}' added to board: '{boardName}' in team: '{teamName}'";
        }
    }
}
