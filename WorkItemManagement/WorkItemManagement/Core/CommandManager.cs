using System;
using System.Collections.Generic;
using System.Linq;
using WorkItemManagement.Commands;
using WorkItemManagement.Commands.Contracts;
using WorkItemManagement.Core.Contracts;

namespace WorkItemManagement.Core
{
    public class CommandManager : ICommandManager
    {
        public ICommand ParseCommand(string command)
        {
            var lineParameters = command.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string commandName = lineParameters[0];
            List<string> commandParameters = lineParameters.Skip(1).ToList();
            return commandName switch
            {
                "createteam" => new CreateTeamCommand(commandParameters,Database.Instance,Factory.Instance), 
                "createmember" => new CreateMemberCommand(commandParameters, Database.Instance, Factory.Instance),
                "createboard" => new CreateBoardCommand(commandParameters, Database.Instance, Factory.Instance), 
                "createbug" => new CreateBugCommand(commandParameters, Database.Instance, Factory.Instance), 
                "createstory" => new CreateStoryCommand(commandParameters, Database.Instance, Factory.Instance),
                "createfeedback" => new CreateFeedbackCommand(commandParameters, Database.Instance, Factory.Instance),
                "showallmembers" => new ShowAllMembersCommand(commandParameters, Database.Instance, Factory.Instance),
                "showallteams" => new ShowAllTeamsCommand(commandParameters, Database.Instance, Factory.Instance),
                "showallboards" => new ShowAllBoardsCommand(commandParameters, Database.Instance, Factory.Instance),
                "showpersonactivity" => new ShowPersonActivityCommand(commandParameters, Database.Instance, Factory.Instance),
                "showallteammembers" => new ShowAllTeamMembersCommand(commandParameters, Database.Instance, Factory.Instance),
                "showteamactivity" => new ShowTeamActivityCommand(commandParameters, Database.Instance, Factory.Instance),
                "showboardactivity" => new ShowBoardActivityCommand(commandParameters, Database.Instance, Factory.Instance),
                "listworkitems" => new ListWorkItemsCommand(commandParameters, Database.Instance, Factory.Instance), 
                "addmember" => new AddMemberCommand(commandParameters, Database.Instance, Factory.Instance), 
                "addcomment" => new AddCommentCommand(commandParameters, Database.Instance, Factory.Instance), 
                "assign" => new AssignCommand(commandParameters, Database.Instance, Factory.Instance), 
                "unassign" => new UnassignCommand(commandParameters, Database.Instance, Factory.Instance), 
                "changebug" => new ChangeBugCommand(commandParameters, Database.Instance, Factory.Instance),          
                "changestory" => new ChangeStoryCommand(commandParameters, Database.Instance, Factory.Instance),      
                "changefeedback" => new ChangeFeedbackCommand(commandParameters, Database.Instance, Factory.Instance),
                "help" => new HelpCommand(),
                _ => throw new InvalidOperationException("Command does not exist.")
            };
        }
    }
}
