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
                "createteam" => new CreateTeamCommand(commandParameters), //done
                "createmember" => new CreateMemberCommand(commandParameters),// done
                "createboard" => new CreateBoardCommand(commandParameters), //done
                "createbug" => new CreateBugCommand(commandParameters), // done
                "createstory" => new CreateStoryCommand(commandParameters),//done
                "createfeedback" => new CreateFeedbackCommand(commandParameters),//done
               /* "showallpeople" =>
                "showallteams" =>
                "showallboards" =>
                "showpersonactivity" =>
                "showteamactivity" =>
                "showboardactivity" =>*/
                "listworkitems" => new ListWorkItemsCommand(commandParameters), // todo
                "addperson" => new AddPersonCommand(commandParameters), //done
                //"addcomment" => 
                "assign" => new AssignCommand(commandParameters),
               // "unassign" =>
                "changebug" => new ChangeBugCommand(commandParameters),          //done
                "changestory" => new ChangeStoryCommand(commandParameters),      //done
                "changefeedback" => new ChangeFeedbackCommand(commandParameters),//done
                _ => throw new InvalidOperationException("Command does not exist.")
            };
        }
    }
}
