using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.Models.Enums;

namespace WorkItemManagement.UnitTests.FakeClasses
{
    public class FakeStory : IStory
    {

        public IMember Assignee => throw new NotImplementedException();

        public PriorityType Priority => throw new NotImplementedException();

        public StoryStatusType StoryStatus => throw new NotImplementedException();

        public SizeType Size => throw new NotImplementedException();

        public string Id { get; set; }

        public string Title => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public IDictionary<IMember, IList<string>> Comments => throw new NotImplementedException();

        public IList<string> History => throw new NotImplementedException();

        public void AddAssignee(IMember member)
        {
            throw new NotImplementedException();
        }

        public void AddComment(IMember member, IList<string> comments)
        {
            throw new NotImplementedException();
        }

        public void AddHistory(string info)
        {
            throw new NotImplementedException();
        }

        public IMember GetAssignee()
        {
            throw new NotImplementedException();
        }

        public void RemoveAssignee()
        {
            throw new NotImplementedException();
        }
    }
}
