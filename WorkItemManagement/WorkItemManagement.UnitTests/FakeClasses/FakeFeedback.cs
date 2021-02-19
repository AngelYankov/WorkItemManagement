using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.Models.Enums;

namespace WorkItemManagement.UnitTests.FakeClasses
{
    public class FakeFeedback : IFeedback
    {
        public int Rating => throw new NotImplementedException();

        public FeedbackStatusType FeedbackStatus => throw new NotImplementedException();

        public string Id {get;}

        public string Title { get; }

        public string Description => throw new NotImplementedException();

        public IDictionary<IMember, IList<string>> Comments => throw new NotImplementedException();

        public IList<string> History => throw new NotImplementedException();

        public void AddComment(IMember member, IList<string> comments)
        {
            throw new NotImplementedException();
        }

        public void AddHistory(string info)
        {
            throw new NotImplementedException();
        }

        public string ChangeStatus(FeedbackStatusType status)
        {
            throw new NotImplementedException();
        }
    }
}
