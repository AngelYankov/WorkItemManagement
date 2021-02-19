using System.Collections.Generic;
using WorkItemManagement.Commands.Abstract;
using WorkItemManagement.Core;
using WorkItemManagement.Core.Contracts;
using WorkItemManagement.Models.Contracts;

namespace WorkItemManagement.Commands
{
    public class AssignCommand : Command
    {
        public AssignCommand(IList<string> commandParameters, IDatabase database, IFactory factory)
            : base(commandParameters, database, factory)
        {
        }
        public override string Execute() // assign member(name) id(workitem)
        {
            var validator = new Validator(Database);
            validator.ValidateParameters(this.CommandParameters, 2);

            string memberName = this.CommandParameters[0];
            string idWorkItem = this.CommandParameters[1];
            var member = Database.GetMember(memberName);
            validator.MemberExistsInAnyTeam(memberName);

            var workItem = Database.GetWorkItemToAssign(idWorkItem); 
            workItem.AddAssignee(member);
            member.AddWorkItems((IWorkItem)workItem);

            return $"Work item: '{idWorkItem}' assigned to '{memberName}'.";
        }
    }
}
