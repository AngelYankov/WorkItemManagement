using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementConsoleApp.Commands.Abstract;
using WorkItemManagementConsoleApp.Core;

namespace WorkItemManagementConsoleApp.Commands
{
    public class CreateFeedbackCommand : Command
    {
        public CreateFeedbackCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }
        public override string Execute() //createfeedback team board id title rating status description
        {
            Validator.ValidateParamsIfLessThan(this.CommandParameters, 7);

            string teamName = this.CommandParameters[0];
            string boardName = this.CommandParameters[1];
            string id = this.CommandParameters[2];
            string title = this.CommandParameters[3];

            if (!int.TryParse(this.CommandParameters[4], out int rating))
            {
                throw new ArgumentException("Rating should be a valid number.");
            }

            string status = this.CommandParameters[5];

            StringBuilder sb = new StringBuilder();
            for (int i = 6; i < this.CommandParameters.Count; i++)
            {
                sb.Append(this.CommandParameters[i]+" ");
            }
            string description = sb.ToString().Trim();

            var existingTeam = Validator.GetTeam(teamName);

            var existingBoard = Validator.GetBoard(boardName, existingTeam);
            
            var feedback = this.Factory.CreateFeedback(id, title, rating, status, description);
            this.Database.AllWorkItems.Add(feedback);
            existingBoard.AddWorkItem(feedback);
            return $"Created feedback: '{title}' with id: '{id}'. Added to board: '{boardName}' in team: '{teamName}'";
        }
    }
}
