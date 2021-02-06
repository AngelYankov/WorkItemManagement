using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Models.Enums;
using WorkItemManagementConsoleApp.Models.Contracts;
using WorkItemManagementConsoleApp.Models.Abstract;

namespace WorkItemManagementConsoleApp.Models.WorkItems
{
    public class Feedback : WorkItem, IFeedback
    {
        public Feedback(string id, string title, string description, IDictionary<Member, List<string>> comments, List<string> history, int rating, FeedbackStatusType status)
            : base(id, title, description, comments, history)
        {
            this.Rating = rating;
            this.FeedbackStatus = status;
        }

        public int Rating { get; }

        public FeedbackStatusType FeedbackStatus { get; }

        /*public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Feedback ----");
            sb.AppendLine($"{this.base}");
            sb.AppendLine($"Rating: {Rating}");
            sb.AppendLine($"Status: {FeedbackStatus}");

            return sb.ToString();
        }*/
    }
}
