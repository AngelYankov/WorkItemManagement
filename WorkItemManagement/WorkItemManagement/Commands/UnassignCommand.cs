using System;
using System.Collections.Generic;
using WorkItemManagement.Commands.Abstract;
using WorkItemManagement.Core;
using WorkItemManagement.Core.Contracts;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.Commands
{
    public class UnassignCommand : Command
    {
        public UnassignCommand(IList<string> commandParameters, IDatabase database, IFactory factory)
            : base(commandParameters, database, factory)
        {
        }

        public override string Execute() //unassign workitem(id)
        {
            var validator = new Validator(Database);
            validator.ValidateParameters(this.CommandParameters, 1);

            string idWorkItem = this.CommandParameters[0];
            var workItem = Database.GetWorkItemToAssign(idWorkItem);
            workItem.GetAssignee().RemoveWorkItems((IWorkItem)workItem);
            workItem.RemoveAssignee();
           
            return $"Work item: '{idWorkItem}' unassigned";
        }
    }
}
