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
        public override string Execute() // assign name workitem
        {
            Validator.ValidateParameters(this.CommandParameters, 2);
            string memberName = this.CommandParameters[0];
            string idWorkItem = this.CommandParameters[1];
            var member = this.Database.AllMembers.FirstOrDefault(m => m.Name.Equals(memberName, StringComparison.OrdinalIgnoreCase));
            if (member == null)
            {
                throw new ArgumentException($"Member: '{memberName}' does not exist.");
            }
            
            //var workItem = this.Database.AllWorkItems.FirstOrDefault(item => item.Id.Equals(idWorkItem, StringComparison.OrdinalIgnoreCase));
            var workItem =(Bug) this.Database.AllWorkItems.FirstOrDefault(item => item.Id.Equals(idWorkItem, StringComparison.OrdinalIgnoreCase));
            
            
            
            if (workItem == null)
            {
                throw new ArgumentException($"Work item: '{idWorkItem}' does not exist.");
            }
            //check if member is in a team
            var existingMemberInTeam = this.Database.AllTeams.Select(t => t.Members).Select(b=>b.FirstOrDefault(m=>m.Name.Equals(memberName,StringComparison.OrdinalIgnoreCase)));
            if (existingMemberInTeam == null)
            {
                throw new ArgumentException("Member doesn't exist.");
            }
            return "1";
            
        }
    }
}
