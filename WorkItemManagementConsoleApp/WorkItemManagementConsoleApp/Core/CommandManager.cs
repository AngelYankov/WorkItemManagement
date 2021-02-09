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
             /*   "createstory" => new CreateStoryCommand(commandParameters),
                "createfeedback" =>
                "showallpeople" =>
                "showallteams" =>
                "showallboards" =>
                "showpersonactivity" =>
                "showteamactivity" =>
                "showboardactivity" =>
                "listworkitems" =>
                "addperson" =>
                "addcomment" => // Team1 Board2 bug1 Angel commentara tuka
                "assign" =>
                "unassign" =>*/
                "changebug" => new ChangeBugCommand(commandParameters),
                /*"changestory" =>
                "changefeedback" =>*/
                _ => throw new InvalidOperationException("Command does not exist.")
            };
        }
    }
}
