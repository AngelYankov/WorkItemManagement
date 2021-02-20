using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.Models.Enums;

namespace WorkItemManagement.UnitTests.FakeClasses
{
    public class FakeFeedback : IFeedback
    {
        private IList<string> history = new List<string>();
        public FakeFeedback() { }
        public FakeFeedback(string id)
        {
            this.Id = id;
            this.Comments = new Dictionary<IMember, IList<string>>();
            this.Title = "DefaultTitle";
        }
        public int Rating { get; set; }

        public FeedbackStatusType FeedbackStatus{ get; set; }

        public string Id { get; set; }

        public string Title { get; }

        public string Description { get; set; }

        public IDictionary<IMember, IList<string>> Comments { get; set; }

        public IList<string> History { get => this.history; }

        public void AddComment(IMember member, IList<string> comments)
        {
            this.Comments.Add(member, comments);
        }

        public void AddHistory(string info)
        {
            this.History.Add(info);
        }

        public string ChangeStatus(FeedbackStatusType status)
        {
            if (this.FeedbackStatus == status)
            {
                throw new ArgumentException($"Status already at '{status}'.");
            }
            this.FeedbackStatus = status;
            return $"Status changed to {status}.";
        }
        public string ChangeRating(int rating)
        {
            if (this.Rating == rating)
            {
                throw new ArgumentException($"Rating already at '{rating}'.");
            }
            this.Rating = rating;
            return $"Rating changed to '{rating}'.";
        }
        private void EnsureRatingIsValid(int rating)
        {
            if (rating < 1 || rating > 10)
            {
                throw new ArgumentException("Rating should be between 1 and 10.");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string comments = this.Comments.Count == 0 ? "No comments" : string.Join(" ", this.Comments);
            string history = this.History.Count == 0 ? "No history" : string.Join(" ", this.History);
            sb.AppendLine("Feedback ----");
            sb.AppendLine($"ID: {this.Id}");
            sb.AppendLine($"Title: {this.Title}");
            sb.AppendLine($"Description: {this.Description}");
            sb.AppendLine($"Activity history: {history}");
            sb.AppendLine($"Comments: {comments}");
            sb.AppendLine($"Rating: {this.Rating}");
            sb.AppendLine($"Status: {this.FeedbackStatus}");

            return sb.ToString().Trim();
        }
    }
}
