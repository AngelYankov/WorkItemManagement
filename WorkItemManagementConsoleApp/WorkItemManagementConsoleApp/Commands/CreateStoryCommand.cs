using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementConsoleApp.Commands.Abstract;
using WorkItemManagementConsoleApp.Core;

namespace WorkItemManagementConsoleApp.Commands
{
    public class CreateStoryCommand : Command
    {
        public CreateStoryCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }
        public override string Execute() // createstory team board id title priority status size description
        {
            Validator.ValidateParamsIfLessThan(this.CommandParameters, 8);

            string teamName = this.CommandParameters[0];
            string boardName = this.CommandParameters[1];
            string id = this.CommandParameters[2];
            string title = this.CommandParameters[3];
            string priority = this.CommandParameters[4];
            string status = this.CommandParameters[5];
            string size = this.CommandParameters[6];
            StringBuilder sb = new StringBuilder();
            for (int i = 7; i < this.CommandParameters.Count; i++)
            {
                sb.Append(this.CommandParameters[i] + " ");
            }
            string description = sb.ToString().Trim();

            var existingTeam = Validator.GetTeam(teamName);

            var existingBoard = Validator.GetBoard(boardName, existingTeam);
            
            var story = this.Factory.CreateStory(id, title, priority, status, size, description);
            existingBoard.AddWorkItem(story);
            this.Database.AllWorkItems.Add(story);
            return $"Created story: '{title}' with id: '{id}'. Added to board: '{boardName}' in team: '{teamName}'";

        }
    }
}
