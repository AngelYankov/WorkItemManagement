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
        public Feedback(string id, string title, string description, int rating, FeedbackStatusType status)
            : base(id, title, description)
        {
            this.Rating = rating;
            this.FeedbackStatus = status;
        }

        public int Rating { get; }

        public FeedbackStatusType FeedbackStatus { get; }

        //Change Rating/Status of a feedback
    }
}
