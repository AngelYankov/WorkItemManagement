using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.Models.Enums;

namespace WorkItemManagement.UnitTests.FakeClasses
{
    public class FakeFeedback : IFeedback
    {
        public FakeFeedback() { }
        public FakeFeedback(string id)
        {
            this.Id = id;
            this.Comments = new Dictionary<IMember, IList<string>>();
            this.Title = "DefaultTitle";
        }
        public int Rating => throw new NotImplementedException();

        public FeedbackStatusType FeedbackStatus => throw new NotImplementedException();

        public string Id { get; set; }

        public string Title { get; }

        public string Description => throw new NotImplementedException();

        public IDictionary<IMember, IList<string>> Comments { get; }

        public IList<string> History => throw new NotImplementedException();

        public void AddComment(IMember member, IList<string> comments)
        {
            this.Comments.Add(member, comments);
        }

        public void AddHistory(string info)
        {
            throw new NotImplementedException();
        }

        public string ChangeRating(int rating)
        {
            throw new NotImplementedException();
        }

        public string ChangeStatus(FeedbackStatusType status)
        {
            throw new NotImplementedException();
        }
    }
}
