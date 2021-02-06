using System;
using System.Collections.Generic;
using System.Text;

namespace WorkItemManagementConsoleApp.WorkItem.Contracts
{
    interface IMember
    {
        public string Name { get; set; }

        public List<IWorkItem> WorkItems { get; set; }

        public List<string> ActivityHistory { get; set; }

        public List<string> ExistingMembers { get; set; }
    }
}
