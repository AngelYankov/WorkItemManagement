using System;
using System.Text;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.Models.Abstract;

namespace WorkItemManagement.Models.WorkItems
{
    public class Feedback : WorkItem, IFeedback
    {
        private int rating;
        private FeedbackStatusType feedbackStatus;
        public Feedback(string id, string title, int rating, string description)
            : base(id, title, description)
        {
            EnsureRatingIsValid(rating);
            this.rating = rating;
            this.feedbackStatus = FeedbackStatusType.New;
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
        /// <summary>
        /// Changing the status of a feeback
        /// </summary>
        /// <param name="status">The status we want the feedback to be changed to</param>
        /// <returns>Returns a string saying what the feedback status has been changed to or returns a message that it is already at the desired status</returns>
        public string ChangeStatus(FeedbackStatusType status)
        {
            if (this.FeedbackStatus== status)
            {
                throw new ArgumentException($"Status already at '{status}'.");
            }
            this.FeedbackStatus = status;
            return $"Status changed to {status}.";
        }
        /// <summary>
        /// Changing the rating of a feedback
        /// </summary>
        /// <param name="rating">The rating we want the feedback to be changed to</param>
        /// <returns>Returns a string saying what the feedback rating has been changed to or returns a message that it is already at the desired rating</returns>
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
