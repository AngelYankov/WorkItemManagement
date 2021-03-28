using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagement.Core.Contracts;
using WorkItemManagement.Models.Contracts;

namespace WorkItemManagement.UnitTests.FakeClasses
{

    public class FakeDatabase : IDatabase
    {
        private readonly IList<IMember> allMembers = new List<IMember>();
        public IList<IMember> AllMembers { get => this.allMembers; }

        private readonly IList<ITeam> allTeams = new List<ITeam>();
        public IList<ITeam> AllTeams { get => this.allTeams; }

        private readonly IList<IWorkItem> allWorkItems = new List<IWorkItem>();
        public IList<IWorkItem> AllWorkItems { get => this.allWorkItems; }

        /// <summary>
        /// Add work item to Database with all work items
        /// </summary>
        /// <param name="workItem">Work Item to be added</param>
        public void AddWorkItemToDB(IWorkItem workItem)
        {
            this.allWorkItems.Add(workItem);
        }

        /// <summary>
        /// Add team to Database with all teams
        /// </summary>
        /// <param name="team">Team to be added</param>
        public void AddTeamToDB(ITeam team)
        {
            this.AllTeams.Add(team);
        }

        /// <summary>
        /// Add member to Database with all members
        /// </summary>
        /// <param name="member">Member to be added</param>
        public void AddMemberToDB(IMember member)
        {
            this.AllMembers.Add(member);
        }

        /// <summary>
        /// Looking for a work item with a given ID
        /// </summary>
        /// <param name="id">The ID of the work item we are searching for</param>
        /// <returns>Returns the the work item with a given ID if it exists or throw an exception if doesn't exist</returns>
        public IWorkItem GetWorkItem(string id)
        {
            var workItem = this.AllWorkItems.FirstOrDefault(item => item.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (workItem == null)
            {
                throw new ArgumentException($"Work item: '{id}' does not exist.");
            }
            return workItem;
        }

        /// <summary>
        /// Looking for a team with a given name 
        /// </summary>
        /// <param name="name">The name of the team we are searching for</param>
        /// <returns>Returns the team if a team with such name exists or throw an exception if it doesn't exist</returns>
        public ITeam GetTeam(string name)
        {
            var team = this.AllTeams.FirstOrDefault(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
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
        public IBoard GetBoard(string name, ITeam team)
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
        public IMember GetMember(string name)
        {
            var member = this.AllMembers.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
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
        public IWorkItemsAssignee GetWorkItemToAssign(string id)
        {
            var item = this.AllWorkItems.FirstOrDefault(item => item.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
            if (item is IFeedback)
            {
                throw new ArgumentException("Feedback doesn't have an assignee.");
            }
            var workItem = (IWorkItemsAssignee)this.AllWorkItems.FirstOrDefault(item => item.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

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
        public IList<IWorkItem> GetAllWorkItems()
        {
            return this.AllWorkItems;
        }

        /// <summary>
        /// Looking for all teams
        /// </summary>
        /// <returns>Returns a list with all teams</returns>
        public IList<ITeam> GetAllTeams()
        {
            return this.AllTeams;
        }

        /// <summary>
        /// Looking for all members
        /// </summary>
        /// <returns>Returns a list with all members</returns>
        public IList<IMember> GetAllMembers()
        {
            return this.AllMembers;
        }
    }
}
