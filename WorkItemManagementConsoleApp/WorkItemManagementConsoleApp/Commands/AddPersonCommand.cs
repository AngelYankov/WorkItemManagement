using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementConsoleApp.Commands.Abstract;
using WorkItemManagementConsoleApp.Core;

namespace WorkItemManagementConsoleApp.Commands
{
    public class AddPersonCommand : Command
    {
        public AddPersonCommand(IList<string> commandParameters)
            :base(commandParameters)
        {
        }
        public override string Execute() // addperson name team1
        {
            Validator.ValidateParameters(this.CommandParameters, 2);
            string memberName = this.CommandParameters[0];
            string teamName = this.CommandParameters[1];

            var member = Validator.GetMember(memberName);
            var team = Validator.GetTeam(teamName);
            Validator.MemberExistsInTeam(memberName, team);

            team.AddMember(member);
            return $"Member: '{memberName}' added to team: '{teamName}'.";
        }
    }
}
