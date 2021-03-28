using System.Collections.Generic;
using WorkItemManagement.Commands.Abstract;
using WorkItemManagement.Core;
using WorkItemManagement.Core.Contracts;

namespace WorkItemManagement.Commands
{
    public class AddMemberCommand : Command
    {
        public AddMemberCommand(IList<string> commandParameters, IDatabase database, IFactory factory)
            : base(commandParameters, database, factory)
        {
        }
        public override string Execute() // addperson name team1
        {
            var validator = new Validator(Database);
            validator.ValidateParameters(this.CommandParameters, 2);
            string memberName = this.CommandParameters[0];
            string teamName = this.CommandParameters[1];

            var member = Database.GetMember(memberName);
            var team = Database.GetTeam(teamName);
            validator.MemberExistsInTeam(memberName, team);

            team.AddMember(member);
            return $"Member: '{memberName}' added to team: '{teamName}'.";
        }
    }
}
