using System.Collections.Generic;
using WorkItemManagement.Commands.Abstract;
using WorkItemManagement.Core;
using WorkItemManagement.Models.Contracts;

namespace WorkItemManagement.Commands
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
            Database.AddMemberToDB(member);
            return $"Created member: '{name}'";
        }
    }
}
