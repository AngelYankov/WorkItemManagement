using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementConsoleApp.Commands.Abstract;
using WorkItemManagementConsoleApp.Core;
using WorkItemManagementConsoleApp.Models.Contracts;
using WorkItemManagementConsoleApp.Models.WorkItems;

namespace WorkItemManagementConsoleApp.Commands
{
    public class AssignCommand : Command
    {
        public AssignCommand(IList<string> commandParameters)
            :base(commandParameters)
        {
        }
        public override string Execute() // assign name id(workitem)
        {
            Validator.ValidateParameters(this.CommandParameters, 2);

            string memberName = this.CommandParameters[0];
            string idWorkItem = this.CommandParameters[1];
            var member = Validator.GetMember(memberName);
            Validator.MemberExistsInAnyTeam(memberName);

            var workItem = Validator.GetWorkItemToAssign(idWorkItem);
            workItem.AddAssignee(member);
            member.AddWorkItems((IWorkItem)workItem);

            return $"Work item: '{idWorkItem}' assigned to '{memberName}'";
        }
    }
}
