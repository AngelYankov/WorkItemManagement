using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Commands.Abstract;
using WorkItemManagementConsoleApp.Core;

namespace WorkItemManagementConsoleApp.Commands
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
            var member = Validator.GetMember(memberName);
            return string.Join("; ", member.ActivityHistory);
        }
    }
}
