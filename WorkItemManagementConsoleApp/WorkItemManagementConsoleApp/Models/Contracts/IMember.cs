using System;
using System.Collections.Generic;
using System.Text;

namespace WorkItemManagementConsoleApp.Models.Contracts
{
    public interface IMember
    {
        string Name { get; }
        IList<IWorkItem> WorkItems { get; }
        IList<string> ActivityHistory { get; }
        void AddWorkItems(IWorkItem item);
        void RemoveWorkItems(IWorkItem item);
        void AddActivityHistory(string info);

    }
}
