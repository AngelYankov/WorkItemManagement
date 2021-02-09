using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementConsoleApp.Commands.Abstract;
using WorkItemManagementConsoleApp.Core;
using WorkItemManagementConsoleApp.Models.Contracts;

namespace WorkItemManagementConsoleApp.Commands
{
    public class CreateMemberCommand : Command
    {
        public CreateMemberCommand(IList<string> commandParameters)
            :base(commandParameters)
        {
        }
        public override string Execute() // createmember member1
        {
            Validator.ValidateParameters(this.CommandParameters, 1);
            string name = this.CommandParameters[0];
            Validator.MemberExists(name);

            IMember member = this.Factory.CreateMember(name);
            this.Database.AllMembers.Add(member);
            return $"Member: '{name}' created";
        }
    }
}
