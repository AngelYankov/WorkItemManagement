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
        private int rating;
        private FeedbackStatusType feedbackStatus;
        public Feedback(string id, string title, int rating, FeedbackStatusType status, string description)
            : base(id, title, description)
        {
            EnsureRatingIsValid(rating);
            this.rating = rating;
            this.feedbackStatus = status;
        }
        public int Rating
        {
            get => this.rating;
            private set
            {
                EnsureRatingIsValid(value);
                this.AddHistory($"Rating changed from '{this.rating}' to '{value}'.");
                this.rating = value;
            }
        }
        public FeedbackStatusType FeedbackStatus
        {
            get => this.feedbackStatus;
            private set
            {
                this.AddHistory($"Feedback status changed from '{this.feedbackStatus}' to '{value}'.");
                this.feedbackStatus = value;
            }
        }
        public string ChangeStatus(FeedbackStatusType status)
        {
            if (this.FeedbackStatus== status)
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
            sb.AppendLine("Feedback ----");
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Rating: {this.rating}");
            sb.AppendLine($"Status: {this.feedbackStatus}");

            return sb.ToString().Trim();
        }
    }
}
