using System;
using System.Collections.Generic;
using System.Linq;
using WorkItemManagement.Core.Contracts;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.Core
{
    public static class Validator
    {
        /// <summary>
        /// Validating the number of parameters added as command by user
        /// </summary>
        /// <param name="parameters">List of parameters added as command by user</param>
        /// <param name="n">Number of parameters</param>
        public static void ValidateParameters(IList<string> parameters,int n)
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
        public static void ValidateParamsIfLessThan(IList<string> parameters, int n)
        {
            if (parameters.Count < n)
            {
                throw new ArgumentException("Parameters count is not valid");
            }
        }
        /// <summary>
        /// Validating if a team with a given name exists
        /// </summary>
        /// <param name="name">The name of the team we are searching for</param>
        public static void TeamExists(string name, IDatabase database)
        {
            bool teamExists = database.AllTeams.Any(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (teamExists)
            {
                throw new ArgumentException($"Team: '{name}' already exists");
            }
        } 
        /// <summary>
        /// Validating if a member with a given name exists
        /// </summary>
        /// <param name="name">The name of the member we are searching for</param>
        public static void MemberExists(string name, IDatabase database)
        {
            bool nameExists = database.AllMembers.Any(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (nameExists)
            {
                throw new ArgumentException($"Member: '{name}' already exists.");
            }
        }
        /// <summary>
        /// Validating if a member with a given name exists in a team with a given name
        /// </summary>
        /// <param name="name">The name of the member we are searching for</param>
        /// <param name="team">The name of the team in which we are searching for the given member</param>
        public static void MemberExistsInTeam(string name,ITeam team)
        {
            bool memberExistsInTeam = team.Members.Any(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (memberExistsInTeam)
            {
                throw new ArgumentException($"Member: '{name}' already exist in team: '{team.Name}'.");
            }
        }
        /// <summary>
        /// Validating if a member with a given name is part of any team
        /// </summary>
        /// <param name="name">The name of the member we are searching for</param>
        public static void MemberExistsInAnyTeam(string name, IDatabase database) // angel
        {
            var isInAnyTeam = database.AllTeams
                               .SelectMany(t => t.Members)
                               .Any(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (!isInAnyTeam)
            {
                throw new ArgumentException($"Member: '{name}' is not in any team.");
            }
        }
        /// <summary>
        /// Validating if a board with a given name exists in a team with a given name
        /// </summary>
        /// <param name="name">The name of the board we are searching for</param>
        /// <param name="team">The name of the team in which we are searching for the given board</param>
        public static void BoardExistsInTeam(string name,ITeam team) // emo
        {
            var boardExists = team.Boards.Any(b => b.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (boardExists)
            {
                throw new ArgumentException($"Board: '{name}' already exists in team: '{team.Name}'");
            }
        }
        /// <summary>
        /// Looking for a team with a given name 
        /// </summary>
        /// <param name="name">The name of the team we are searching for</param>
        /// <returns>Returns the team if a team with such name exists or throw an exception if it doesn't exist</returns>
        public static ITeam GetTeam(string name, IDatabase database) //angel
        {
            var team = database.AllTeams.FirstOrDefault(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (team == null)
            {
                throw new ArgumentException($"Team: '{name}' does not exist.");
            }
            return team;
        }
        /// <summary>
        /// Looking for a board with a given name within a team with a given name
        /// </summary>
        /// <param name="name">The name of the board we are searching for</param>
        /// <param name="team">the name of the team in which we are searching for the board</param>
        /// <returns>Returns the board if a board with a given name exists in a team with a given name or throw an exception that it doesn't exist in the that team.</returns>
        public static IBoard GetBoard(string name,ITeam team) // emo
        {
            var existingBoard = team.Boards.FirstOrDefault(b => b.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (existingBoard == null)
            {
                throw new ArgumentException($"Board: '{name}' does not exist in team:'{team.Name}'.");
            }
            return existingBoard;
        }
        /// <summary>
        /// Looking for a member with a given name
        /// </summary>
        /// <param name="name">The name of the member we are searching for</param>
        /// <returns>Returns the member if a member with a given name exists or throw an exception that it doesn't exist</returns>
        public static IMember GetMember(string name, IDatabase database) // angel
        {
            var member = database.AllMembers.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (member == null)
            {
                throw new ArgumentException($"Member: '{name}' does not exist.");
            }
            return member;
        }
        /// <summary>
        /// Looking for a workitem with a given ID
        /// </summary>
        /// <param name="id">The ID of the work item we are searching for</param>
        /// <returns>Returns the the work item with a given ID if it exists or throw an exception that it doesn't exist</returns>
        public static IWorkItemsAssignee GetWorkItemToAssign(string id, IDatabase database) // emo
        {
            if (database.AllWorkItems.FirstOrDefault(item => item.Id.Equals(id, StringComparison.OrdinalIgnoreCase)) is Feedback)
            {
                throw new ArgumentException("Feedback don't have an assignee.");
            }
            var workItem = (IWorkItemsAssignee)database.AllWorkItems.FirstOrDefault(item => item.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (workItem == null)
            {
                throw new ArgumentException($"Work item: '{id}' does not exist.");
            }
            return workItem;
        }
        /// <summary>
        /// Looking for a work item with a given ID
        /// </summary>
        /// <param name="id">The ID of the work item we are searching for</param>
        /// <returns>Returns the the work item with a given ID if it exists or throw an exception if doesn't exist</returns>
        public static IWorkItem GetWorkItem(string id, IDatabase database)//angel
        {
            var workItem = database.AllWorkItems.FirstOrDefault(item => item.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (workItem == null)
            {
                throw new ArgumentException($"Work item: '{id}' does not exist.");
            }
            return workItem;
        }
        /// <summary>
        /// Looking for all of the work items
        /// </summary>
        /// <returns>Returns a list with all work items</returns>
        public static IList<IWorkItem> GetAllWorkItems(IDatabase database) // emo
        {
            return database.AllWorkItems;
        }
        /// <summary>
        /// Looking for all teams
        /// </summary>
        /// <returns>Returns a list with all teams</returns>
        public static IList<ITeam> GetAllTeams(IDatabase database)//angel
        {
            return database.AllTeams;
        }
        /// <summary>
        /// Looking for all members
        /// </summary>
        /// <returns>Returns a list with all members</returns>
        public static IList<IMember> GetAllMembers(IDatabase database)//angel
        {
            return database.AllMembers;
        }
    }
}
