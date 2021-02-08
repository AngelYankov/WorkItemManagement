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
        public Feedback(string id, string title, string description, int rating, FeedbackStatusType status)
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
                if (value < 1 || value > 10)
                {
                    throw new ArgumentException("Rating should be between 1 and 10.");
                }
                this.AddHistory($"Rating changed from {this.rating} to {value}.");
                this.rating = value;
            }
        }
        public FeedbackStatusType FeedbackStatus
        {
            get => this.feedbackStatus;
            private set
            {
                this.AddHistory($"Feedback status changed from {this.feedbackStatus} to {value}.");
                this.feedbackStatus = value;
            }
        }
        private void EnsureRatingIsValid(int rating)
        {
            if (rating < 1 || rating > 10)
            {
                throw new ArgumentException("Rating should be between 1 and 10.");
            }
        }
    }
}
