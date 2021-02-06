using System;
using System.Collections.Generic;
using System.Text;

namespace WorkItemManagementConsoleApp.Models.Contracts
{
    public interface IBoard
    {
        string Name { get; }
        List<IWorkItem> WorkItems { get; }
        List<string> ActivityHistory { get; }

    }
}
