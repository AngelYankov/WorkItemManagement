using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Core.Contracts;
using WorkItemManagementConsoleApp.Models.Contracts;

namespace WorkItemManagementConsoleApp.Core
{
    public class Database : IDatabase
    {
        private static IDatabase instance;

        public static IDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Database(); 
                }
                return instance;
            }
        }
        private readonly IList<IMember> allMembers = new List<IMember>();
        public IList<IMember> AllMembers { get => this.allMembers; }

        private readonly IList<ITeam> allTeams = new List<ITeam>();
        public IList<ITeam> AllTeams { get => this.allTeams; }

        private readonly IList<IWorkItem> allWorkItems = new List<IWorkItem>();
        public IList<IWorkItem> AllWorkItems { get => this.allWorkItems; }

    }
}
