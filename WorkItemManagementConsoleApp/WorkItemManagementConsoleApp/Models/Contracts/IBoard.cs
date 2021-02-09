using System;
using System.Collections.Generic;
using System.Text;

namespace WorkItemManagementConsoleApp.Models.Contracts
{
    public interface IBoard
    {
        string Name { get; }
        IList<IWorkItem> WorkItems { get; }
        IList<string> ActivityHistory { get; }
        void AddWorkItem(IWorkItem item);
    }
}
