using System.Collections.Generic;

namespace WorkItemManagement.Models.Contracts
{
    public interface IBoard
    {
        string Name { get; }
        IList<IWorkItem> WorkItems { get; }
        IList<string> ActivityHistory { get; }
        void AddWorkItem(IWorkItem item);
    }
}
