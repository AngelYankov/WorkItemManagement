using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementConsoleApp.Commands.Abstract;

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
            if (this.CommandParameters.Count != 2 )
            {
                throw new ArgumentException("Parameters count is not valid.");
            }
            string memberName = this.CommandParameters[0];
            string teamName = this.CommandParameters[1];
            var member = this.Database.AllMembers.FirstOrDefault(m => m.Name.Equals(memberName, StringComparison.OrdinalIgnoreCase));
            if (member == null)
            {
                throw new ArgumentException($"Member: '{memberName}' does not exist.");
            }
            var team = this.Database.AllTeams.FirstOrDefault(t => t.Name.Equals(teamName, StringComparison.OrdinalIgnoreCase));
            if (team == null)
            {
                throw new ArgumentException($"Team: '{teamName}' does not exist.");
            }
            if (team.Members.Any(m=>m.Name.Equals(member.Name,StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"Member: '{memberName}' already exist in team: '{teamName}'.");
            }
            team.AddMember(member);
            return $"Member: '{memberName}' added to team: '{teamName}'.";
        }
    }
}
