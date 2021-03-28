using System.Collections.Generic;
using WorkItemManagement.Commands.Abstract;
using WorkItemManagement.Core;
using WorkItemManagement.Core.Contracts;
using WorkItemManagement.Models.Contracts;

namespace WorkItemManagement.Commands
{
    public class CreateMemberCommand : Command
    {
        public CreateMemberCommand(IList<string> commandParameters, IDatabase database, IFactory factory)
            : base(commandParameters, database, factory)
        {
        }
        public override string Execute() // createmember member1
        {
            var validator = new Validator(Database);

            validator.ValidateParameters(this.CommandParameters, 1);
            string name = this.CommandParameters[0];
            validator.MemberExists(name);

            IMember member = this.Factory.CreateMember(name);
            Database.AddMemberToDB(member);
            return $"Created member: '{name}'";
        }
    }
}
