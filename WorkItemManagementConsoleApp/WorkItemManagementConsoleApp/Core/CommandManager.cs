using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementConsoleApp.Commands;
using WorkItemManagementConsoleApp.Commands.Contracts;
using WorkItemManagementConsoleApp.Core.Contracts;

namespace WorkItemManagementConsoleApp.Core
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
                "createteam" => new CreateTeamCommand(commandParameters), 
                "createmember" => new CreateMemberCommand(commandParameters),
                "createboard" => new CreateBoardCommand(commandParameters), 
                "createbug" => new CreateBugCommand(commandParameters), 
                "createstory" => new CreateStoryCommand(commandParameters),
                "createfeedback" => new CreateFeedbackCommand(commandParameters),
                "showallmembers" => new ShowAllMembersCommand(commandParameters),
                "showallteams" => new ShowAllTeamsCommand(commandParameters),
                "showallboards" => new ShowAllBoardsCommand(commandParameters),
                "showpersonactivity" => new ShowPersonActivityCommand(commandParameters),
                "showallteammembers" => new ShowAllTeamMembers(commandParameters),
                "showteamactivity" => new ShowTeamActivityCommand(commandParameters),
                "showboardactivity" => new ShowBoardActivityCommand(commandParameters),
                "listworkitems" => new ListWorkItemsCommand(commandParameters), 
                "addmember" => new AddMemberCommand(commandParameters), 
                "addcomment" => new AddCommentCommand(commandParameters), 
                "assign" => new AssignCommand(commandParameters), 
                "unassign" => new UnassignCommand(commandParameters), 
                "changebug" => new ChangeBugCommand(commandParameters),          
                "changestory" => new ChangeStoryCommand(commandParameters),      
                "changefeedback" => new ChangeFeedbackCommand(commandParameters),
                "help" => new HelpCommand(),
                _ => throw new InvalidOperationException("Command does not exist.")
            };
        }
    }
}
