
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
                case "bug":
                    filteredList = (IList<IWorkItem>)FilterBug(this.CommandParameters.Skip(1).ToList());
                    break;
                case "story":
                    filteredList = (IList<IWorkItem>)FilterStory(this.CommandParameters.Skip(1).ToList());
                    break;
                default:
                    throw new ArgumentException("Not a valid filtering command");

            }
            return string.Join(", ", filteredList);
        }
        private IList<IFeedback> FilterFeedback(IList<string> commands) //new unscheduled scheduled done  //title/rating
        {
            var feedbacks = Validator.GetAllWorkItems().OfType<IFeedback>().ToList();
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

        private List<IFeedback> FilterFeedbackByStatus(string status, List<IFeedback> feedbacks)
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
        private List<IFeedback> SortFeedbackBy(string sort, List<IFeedback> feedbacks)
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

        private List<IBug> FilterBug(IList<string> commands) //active/fixed/assignee
        {
            var bugs = Validator.GetAllWorkItems().OfType<IBug>().ToList();
            if (commands.Count == 0)
            {
                return bugs;
            }
            else if (commands.Count == 1)
            {
                return FilterBugByStatusOrAssignee(commands[0], bugs);
            }
            else if (commands.Count == 2)
            {
                bugs = FilterBugByStatusOrAssignee(commands[0], bugs);
                return SortBug(commands[1], bugs);
            }
            else if (commands.Count == 3)
            {
                bugs = FilterBugByStatusOrAssignee(commands[0], bugs);
                bugs = SortBug(commands[1], bugs);
                return SortBug(commands[2], bugs);
            }
            else
            {
                throw new ArgumentException("Bug filter count is not valid.");
            }
        }

        private List<IBug> FilterBugByStatusOrAssignee(string filter, List<IBug> bugs)
        {
            switch (filter)
            {
                case "active":
                case "fixed":
                    return bugs.Where(b => b.Status.ToString().Equals(filter, StringComparison.OrdinalIgnoreCase)).ToList();
                default:
                    return FilterBugAssignee(filter, bugs);
            }
        }

        private List<IBug> FilterBugAssignee(string filter, List<IBug> bugs)
        {
            if (!bugs.Any(b => b.Assignee.Name.Equals(filter, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"There is no filter: '{filter}' for bug.");
            }
            return bugs.Where(b => b.Assignee.Name.Equals(filter, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        private List<IBug> SortBug(string filter, List<IBug> bugs)
        {
            switch (filter)
            {
                case "title":
                    return bugs.OrderBy(b => b.Title).ToList();
                case "severity":
                    return bugs.OrderBy(b => b.Severity).ToList();
                case "priority":
                    return bugs.OrderBy(b => b.Priority).ToList();
                default:
                    return FilterBugAssignee(filter, bugs);
            }
        }

        private List<IStory> FilterStory(List<string> commands)
        {
            var stories = Validator.GetAllWorkItems().OfType<IStory>().ToList();
            if (commands.Count == 0)
            {
                return stories;
            }
            else if (commands.Count == 1)
            {
                return FilterStoryByStatusOrAssignee(commands[0], stories).ToList();
            }
            else if (commands.Count == 2)
            {
                stories = FilterStoryByStatusOrAssignee(commands[0], stories);
                return SortStory(commands[1], stories);
            }
            else if (commands.Count == 3)
            {
                stories = FilterStoryByStatusOrAssignee(commands[0], stories);
                stories = SortStory(commands[1], stories);
                return SortStory(commands[2], stories);
            }
            else
            {
                throw new ArgumentException("Story filter count is not valid.");
            }
        }

        private List<IStory> FilterStoryByStatusOrAssignee(string filter, List<IStory> stories)
        {
            switch (filter)
            {
                case "notdone":
                case "inprogress":
                case "done":
                    return stories.Where(s => s.StoryStatus.ToString().Equals(filter, StringComparison.OrdinalIgnoreCase)).ToList();
                default:
                    return FilterStoryAssignee(filter, stories);
            }
        }

        private List<IStory> FilterStoryAssignee(string filter, List<IStory> stories)
        {
            if (!stories.Any(s => s.Assignee.Name.Equals(filter, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"There is no filter: '{filter}' for story.");
            }
            return stories.Where(s => s.Assignee.Name.Equals(filter, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        private List<IStory> SortStory(string filter, List<IStory> stories)
        {
            switch (filter)
            {
                case "title":
                    return stories.OrderBy(s => s.Title).ToList();
                case "size":
                    return stories.OrderBy(s => s.Size).ToList();
                case "priority":
                    return stories.OrderBy(s => s.Priority).ToList();
                default:
                    return FilterStoryAssignee(filter, stories);
            }
        }
    }
}

