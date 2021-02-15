using System.Collections.Generic;

namespace WorkItemManagement.Models.Contracts
{
    public interface IWorkItem
    {
        string Id { get; }
        string Title { get; }
        string Description { get; }
        IDictionary<IMember, IList<string>> Comments { get; }
        IList<string> History { get; }
        void AddHistory(string info);
        public void AddComment(IMember member, IList<string> comments);
        
    }
}
