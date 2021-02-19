using System.Collections.Generic;
using WorkItemManagement.Commands.Abstract;
using WorkItemManagement.Core;

namespace WorkItemManagement.Commands
{
    public class ShowPersonActivityCommand : Command
    {
        public ShowPersonActivityCommand(IList<string> commandParameters)
            :base(commandParameters)
        {
        }
        public override string Execute() //showpersonactivity member(name)
        {
            Validator.ValidateParameters(this.CommandParameters, 1);
            string memberName = this.CommandParameters[0];
            var member = Validator.GetMember(memberName, Database);
            return string.Join("; ", member.ActivityHistory);
        }
    }
}
