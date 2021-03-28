using System.Collections.Generic;
using WorkItemManagement.Commands.Abstract;
using WorkItemManagement.Core;
using WorkItemManagement.Core.Contracts;

namespace WorkItemManagement.Commands
{
    public class ShowPersonActivityCommand : Command
    {
        public ShowPersonActivityCommand(IList<string> commandParameters, IDatabase database, IFactory factory)
            : base(commandParameters, database, factory)
        {
        }
        public override string Execute() //showpersonactivity member(name)
        {
            var validator = new Validator(Database);
            validator.ValidateParameters(this.CommandParameters, 1);
            string memberName = this.CommandParameters[0];
            var member = Database.GetMember(memberName);
            return member.ActivityHistory.Count != 0
                ? string.Join("; ", member.ActivityHistory)
                : "No history added.";
        }
    }
}
