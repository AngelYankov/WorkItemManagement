﻿using System.Collections.Generic;
using System.Linq;
using WorkItemManagement.Commands.Abstract;
using WorkItemManagement.Core;

namespace WorkItemManagement.Commands
{
    public class ShowAllMembersCommand : Command
    {
        public ShowAllMembersCommand(IList<string> commandParameters)
            :base(commandParameters)
        {
        }
        public override string Execute()
        {
            Validator.ValidateParameters(this.CommandParameters, 0);
            return Validator.GetAllMembers(Database).Count != 0 
                ? string.Join(", ", Validator.GetAllMembers(Database).Select(m => m.Name)) 
                : "There are no members.";
        }
    }
}
