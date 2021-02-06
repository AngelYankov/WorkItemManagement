using System;
using System.Collections.Generic;
using System.Text;

namespace WorkItemManagementConsoleApp.Models.Contracts
{
    public interface IMember
    {
        string Name { get; set; }

        List<IWorkItem> WorkItems { get; set; }

        List<string> ActivityHistory { get; set; }

        List<string> ExistingMembers { get; set; }
    }
}
