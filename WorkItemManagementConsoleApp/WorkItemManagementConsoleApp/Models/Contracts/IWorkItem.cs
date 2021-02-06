using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Models.WorkItems;

namespace WorkItemManagementConsoleApp.Models.Contracts
{
    public interface IWorkItem
    {
        static int Id { get; }
        string Title { get; }
        string Description { get; }
        IDictionary<Member, List<string>> Comments { get; }
        List<string> History { get; }
    }
}
