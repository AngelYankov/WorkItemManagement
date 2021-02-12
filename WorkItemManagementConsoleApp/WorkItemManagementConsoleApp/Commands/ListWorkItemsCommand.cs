
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementConsoleApp.Commands.Abstract;
using WorkItemManagementConsoleApp.Core;
using WorkItemManagementConsoleApp.Models.Contracts;
using WorkItemManagementConsoleApp.Models.WorkItems;

namespace WorkItemManagementConsoleApp.Commands
{
    public class ListWorkItemsCommand : Command
    {
        public ListWorkItemsCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }
        public override string Execute() // listworkitems all/bug/story/feedback 
                                         //listworkitems status or/and assignee
                                         //listworkitems title/priority/severity/size/rating
        {
            Validator.ValidateParamsIfLessThan(this.CommandParameters, 1);

            IList<IWorkItem> filteredList = new List<IWorkItem>();

            switch (this.CommandParameters[0])
            {
                case "all":
                    filteredList = Validator.GetAllWorkItems();
                    break;
                case "feedback":
                    filteredList = (IList<IWorkItem>)FilterFeedback(this.CommandParameters.Skip(1).ToList());
                    break;

            }
            return string.Join(", ", filteredList);
        }
        private IList<IFeedback> FilterFeedback(IList<string> commands) //new unscheduled scheduled done  //title/rating
        {
            IList<IFeedback> feedbacks = Validator.GetAllWorkItems().OfType<IFeedback>().ToList();
            if (commands.Count == 0)
            {
                return feedbacks;
            }
            else if (commands.Count == 1)
            {
                return FilterFeedbackByStatus(commands[0], feedbacks);
            }
            else if (commands.Count == 2)
            {
                feedbacks = FilterFeedbackByStatus(commands[0], feedbacks);
                return SortFeedbackBy(commands[1], feedbacks);
            }
            else throw new ArgumentException("Feedback filter count is not valid.");
            
        }

        private IList<IFeedback> FilterFeedbackByStatus(string status, IList<IFeedback> feedbacks)
        {
            switch (status)
            {
                case "new":
                case "unscheduled":
                case "scheduled":
                case "done":
                    return feedbacks.Where(f => f.FeedbackStatus.ToString().Equals(status, StringComparison.OrdinalIgnoreCase)).ToList();
                default: throw new ArgumentException($"Feedback status: '{status}' is not valid");
            }
        }
        private IList<IFeedback> SortFeedbackBy(string sort, IList<IFeedback> feedbacks)
        {
            switch (sort)
            {
                case "title":
                    return feedbacks.OrderBy(f => f.Title).ToList();
                case "rating":
                    return feedbacks.OrderBy(f => f.Rating).ToList();
                default: throw new ArgumentException($"Feedback sort: '{sort}' is not valid.");
            }
        }

    }
}
