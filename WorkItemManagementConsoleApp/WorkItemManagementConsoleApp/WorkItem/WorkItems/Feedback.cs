using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Common;
using WorkItemManagementConsoleApp.WorkItem.Contracts;

namespace WorkItemManagementConsoleApp.WorkItem.WorkItems
{
    class Feedback : WorkItem, IFeedback
    {
        private int rating;

        public Feedback(int Id, string title, string description, IDictionary<string, List<string>> comments, List<string> history, int rating, FeedbackStatusType status)
            : base(int Id, string title, string description, IDictionary<string, List<string>> comments, List<string> history)
        {
            this.Rating = rating;
        }

        public int Rating { get => this.rating; }

        public FeedbackStatusType FeedbackStatus { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Feedback ----");
            sb.AppendLine($"{this.base}");
            sb.AppendLine($"Rating: {Rating}");
            sb.AppendLine($"Status: {FeedbackStatus}");

            return sb.ToString();
        }
    }
}
