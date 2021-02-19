using System;
using System.Collections.Generic;
using System.Linq;
using WorkItemManagement.Commands.Abstract;
using WorkItemManagement.Core;

namespace WorkItemManagement.Commands
{
    public class CreateFeedbackCommand : Command
    {
        public CreateFeedbackCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }
        public override string Execute() //createfeedback team board id title rating status description
        {
            Validator.ValidateParamsIfLessThan(this.CommandParameters, 6);

            string teamName = this.CommandParameters[0];
            string boardName = this.CommandParameters[1];
            string id = this.CommandParameters[2];
            string title = this.CommandParameters[3];

            if (!int.TryParse(this.CommandParameters[4], out int rating))
            {
                throw new ArgumentException("Rating should be a valid number.");
            }

            string description = string.Join(" ", this.CommandParameters.Skip(5));
            var existingTeam = Database.GetTeam(teamName);
            var existingBoard = Database.GetBoard(boardName, existingTeam);
            
            var feedback = this.Factory.CreateFeedback(id, title, rating, description);

            existingBoard.AddWorkItem(feedback);
            Database.AddWorkItemToDB(feedback);

            return $"Created feedback: '{title}' with id: '{id}'. Added to board: '{boardName}' in team: '{teamName}'";
        }
    }
}
