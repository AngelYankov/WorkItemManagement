using System.Collections.Generic;
using System.Linq;
using WorkItemManagement.Commands.Abstract;
using WorkItemManagement.Core;

namespace WorkItemManagement.Commands
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
            string description = string.Join(" ", this.CommandParameters.Skip(8));

            var existingTeam = Validator.GetTeam(teamName);
            var existingBoard = Validator.GetBoard(boardName, existingTeam);
            
            var bug = this.Factory.CreateBug(id, title, priority, severity, status, steps, description);
            existingBoard.AddWorkItem(bug);
            Validator.GetAllWorkItems().Add(bug);

            return $"Created bug: '{title}' with id: '{id}'. Added to board: '{boardName}' in team: '{teamName}'";
        }
    }
}
