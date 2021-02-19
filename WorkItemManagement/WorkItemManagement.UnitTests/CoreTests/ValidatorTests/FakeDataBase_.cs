using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core.Contracts;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.UnitTests.CoreTests.ValidatorTests
{
    public class FakeDatabase : IDatabase
    {
        private readonly IList<ITeam> teams = new List<ITeam>();
        private readonly IList<IMember> members = new List<IMember>();
        private readonly IList<IWorkItem> workItems = new List<IWorkItem>();
        public IList<IMember> AllMembers => this.members;
        public IList<ITeam> AllTeams => this.teams;
        public IList<IWorkItem> AllWorkItems => this.workItems;

        public void AddMember(IMember member)
        {
            AllMembers.Add(member);
        }
        public void AddTeam(ITeam team)
        {
            AllTeams.Add(team);
        }
        public void AddWorkItem(IWorkItem workitem)
        {
            AllWorkItems.Add(workitem);
        }
        public void AddBoardToTeam(ITeam team, IBoard board)
        {
            team.AddBoard(board);
        }
    }
   
}
