using System.Collections.Generic;
using System.Linq;
using WorkItemManagement.Commands.Abstract;
using WorkItemManagement.Core;
using WorkItemManagement.Core.Contracts;

namespace WorkItemManagement.Commands
{
    public class CreateStoryCommand : Command
    {
        public CreateStoryCommand(IList<string> commandParameters, IDatabase database, IFactory factory)
            : base(commandParameters, database, factory)
        {
        }
        public override string Execute() // createstory team board id title priority size description
        {
            var validator = new Validator(Database);

            validator.ValidateParamsIfLessThan(this.CommandParameters, 7);

            string teamName = this.CommandParameters[0];
            string boardName = this.CommandParameters[1];
            string id = this.CommandParameters[2];
            string title = this.CommandParameters[3];
            string priority = this.CommandParameters[4];
            string size = this.CommandParameters[5];
            string description = string.Join(" ", this.CommandParameters.Skip(6));

            var existingTeam = Database.GetTeam(teamName);
            var existingBoard = Database.GetBoard(boardName, existingTeam);
            
            var story = this.Factory.CreateStory(id, title, priority, size, description);

            existingBoard.AddWorkItem(story);
            Database.AddWorkItemToDB(story);

            return $"Created story: '{title}' with id: '{id}'. Added to board: '{boardName}' in team: '{teamName}'";

        }
    }
}
