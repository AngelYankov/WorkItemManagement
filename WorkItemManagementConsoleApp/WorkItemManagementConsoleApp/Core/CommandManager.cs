using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                "createmember" => 
                "createteam" =>
                "createboard" =>
                "createbug" =>
                "createstory" =>
                "createfeedback" =>
                "showallpeople" =>
                "showallteams" =>
                "showallboards" =>
                "showpersonactivity" =>
                "showteamactivity" =>
                "showboardactivity" =>
                "listworkitems" =>
                "addperson" =>
                "addcomment" => // Team1 Board2 Angel commentara tuka
                "assign" =>
                "unassign" =>
                "changebug" => // Priority High
                "changestory" =>
                "changefeedback" =>
                _ => throw new InvalidOperationException("Command does not exist.")
            };
        }
    }
}
