using System;
using System.Collections.Generic;
using WorkItemManagement.Commands.Abstract;
using WorkItemManagement.Core;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.Commands
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
            var workItem = Validator.GetWorkItemToAssign(idWorkItem, Database);
            workItem.GetAssignee().RemoveWorkItems((IWorkItem)workItem);
            workItem.RemoveAssignee();
           
            return $"Work item: '{idWorkItem}' unassigned";
        }
    }
}
