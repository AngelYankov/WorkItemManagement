using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementConsoleApp.Commands.Abstract;
using WorkItemManagementConsoleApp.Core;

namespace WorkItemManagementConsoleApp.Commands
{
    public class ShowAllPeopleCommand : Command
    {
        public ShowAllPeopleCommand(IList<string> commandParameters)
            :base(commandParameters)
        {
        }
        public override string Execute()
        {
            Validator.ValidateParameters(this.CommandParameters, 0);
            return Validator.GetAllMembers().Count != 0 
                ? string.Join(", ", Validator.GetAllMembers().Select(m => m.Name)) 
                : "There are no members.";
        }
    }
}
