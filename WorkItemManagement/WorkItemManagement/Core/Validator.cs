using System;
using System.Collections.Generic;
using System.Linq;
using WorkItemManagement.Core.Contracts;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.Core
{
    public class Validator : IValidator
    {
        public IDatabase Database { get;}
        
        public Validator(IDatabase database) 
        {
            this.Database = database;
        }
        /// <summary>
        /// Validating the number of parameters added as command by user
        /// </summary>
        /// <param name="parameters">List of parameters added as command by user</param>
        /// <param name="n">Number of parameters</param>
        public void ValidateParameters(IList<string> parameters,int n)
        {
            if (parameters.Count != n)
            {
                throw new ArgumentException("Parameters count is not valid");
            }
        }
        /// <summary>
        /// Validating the number of parameters added as command by user
        /// </summary>
        /// <param name="parameters">List of parameters added as command by user</param>
        /// <param name="n">Number of parameters</param>
        public void ValidateParamsIfLessThan(IList<string> parameters, int n)
        {
            if (parameters.Count < n)
            {
                throw new ArgumentException("Parameters count is not valid");
            }
        }
        
        /// <summary>
        /// Validating if a member with a given name exists in a team with a given name
        /// </summary>
        /// <param name="name">The name of the member we are searching for</param>
        /// <param name="team">The name of the team in which we are searching for the given member</param>
        public void MemberExistsInTeam(string name,ITeam team)
        {
            bool memberExistsInTeam = team.Members.Any(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (memberExistsInTeam)
            {
                throw new ArgumentException($"Member: '{name}' already exist in team: '{team.Name}'.");
            }
        }
        
        /// <summary>
        /// Validating if a board with a given name exists in a team with a given name
        /// </summary>
        /// <param name="name">The name of the board we are searching for</param>
        /// <param name="team">The name of the team in which we are searching for the given board</param>
        public void BoardExistsInTeam(string name,ITeam team) 
        {
            var boardExists = team.Boards.Any(b => b.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (boardExists)
            {
                throw new ArgumentException($"Board: '{name}' already exists in team: '{team.Name}'");
            }
        }

        /// <summary>
        /// Validating if a team with a given name exists
        /// </summary>
        /// <param name="name">The name of the team we are searching for</param>
        public void TeamExists(string name)
        {
            bool teamExists = Database.AllTeams.Any(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (teamExists)
            {
                throw new ArgumentException($"Team: '{name}' already exists");
            }
        }

        /// <summary>
        /// Validating if a member with a given name exists
        /// </summary>
        /// <param name="name">The name of the member we are searching for</param>
        public void MemberExists(string name)
        {
            bool nameExists = Database.AllMembers.Any(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (nameExists)
            {
                throw new ArgumentException($"Member: '{name}' already exists.");
            }
        }

        /// <summary>
        /// Validating if a member with a given name is part of any team
        /// </summary>
        /// <param name="name">The name of the member we are searching for</param>
        public void MemberExistsInAnyTeam(string name)
        {
            var isInAnyTeam = Database.AllTeams
                               .SelectMany(t => t.Members)
                               .Any(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (!isInAnyTeam)
            {
                throw new ArgumentException($"Member: '{name}' is not in any team.");
            }
        }

        /// <summary>
        /// Validate if Member has certain work item
        /// </summary>
        /// <param name="workItem">Work item to check for</param>
        /// <param name="member">Member to have the work item</param>
        public void MemberHasWorkItem(IWorkItem workItem,IMember member)
        {
            if (!member.WorkItems.Contains(workItem))
            {
                throw new ArgumentException($"Member: '{member.Name}' does not have access to work item: '{workItem.Id}'.");
            }
        }

    }
}
