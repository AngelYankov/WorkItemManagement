﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementConsoleApp.Commands.Abstract;
using WorkItemManagementConsoleApp.Core;

namespace WorkItemManagementConsoleApp.Commands
{
    public class ShowAllBoardsCommand : Command
    {
        public ShowAllBoardsCommand(IList<string> commandParameters)
            :base(commandParameters)
        {
        }
        public override string Execute()
        {
            Validator.ValidateParameters(this.CommandParameters, 0);
            return string.Join(", ", this.Database.AllTeams
                                    .SelectMany(t => t.Boards)
                                    .Select(b => b.Name)); 
        }
    }
}
