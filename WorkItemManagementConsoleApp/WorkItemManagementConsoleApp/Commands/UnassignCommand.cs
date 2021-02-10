using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementConsoleApp.Commands.Abstract;
using WorkItemManagementConsoleApp.Core;
using WorkItemManagementConsoleApp.Models.Contracts;

namespace WorkItemManagementConsoleApp.Commands
{
    public class UnassignCommand : Command
    {
        public UnassignCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }

        public override string Execute() //unassign workitem(id)
        {
            Validator.ValidateParameters(this.CommandParameters, 1);

            string idWorkItem = this.CommandParameters[0];
            var workItem = Validator.GetWorkItemToAssign(idWorkItem);
            workItem.GetAssignee().RemoveWorkItems((IWorkItem)workItem);
            workItem.RemoveAssignee();
           
            return $"'{idWorkItem}' unassigned";
        }
    }
}
