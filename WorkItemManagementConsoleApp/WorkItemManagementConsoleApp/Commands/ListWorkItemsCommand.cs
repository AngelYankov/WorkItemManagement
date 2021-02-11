
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
            // Validator.ValidateParameters(CommandParameters, 1);
            // string items = CommandParameters[0];
            /* StringBuilder sb = new StringBuilder();
             switch (CommandParameters[0])
             {
                 case "all":
                     this.Database.AllWorkItems.ToList().ForEach(i => sb.AppendLine(i.ToString()));
                     return sb.ToString().Trim();
                 case "bug":
                     this.Database.AllWorkItems.Where(i => i is Bug).ToList().ForEach(b => sb.AppendLine(b.ToString()));
                     return sb.ToString().Trim();
                 case "story":
                     this.Database.AllWorkItems.Where(i => i is Story).ToList().ForEach(s => sb.AppendLine(s.ToString()));
                     return sb.ToString().Trim();
                 case "feedback":
                     this.Database.AllWorkItems.Where(i => i is Feedback).ToList().ForEach(b => sb.AppendLine(b.ToString()));
                     return sb.ToString().Trim();
             }
             return sb.ToString();*/
            IList<IWorkItem> filteredList = new List<IWorkItem>();
            IList<IBug> bugList = new List<IBug>();
            IList<IStory> storyList = new List<IStory>();
            IList<IFeedback> feedbackList = new List<IFeedback>();

            if (this.CommandParameters.Count == 0)
            {
                filteredList = Validator.GetAllWorkItems();
            }
            else if (this.CommandParameters.Count == 1) // listworkitems bug
            {
                if (this.CommandParameters[0] == "bug")
                {
                    bugList = Validator.GetAllWorkItems().OfType<IBug>().ToList();
                }
                else if (this.CommandParameters[0] == "story")
                {
                    storyList = Validator.GetAllWorkItems().OfType<IStory>().ToList();
                }
                else if (this.CommandParameters[0] == "feedback")
                {
                    feedbackList = Validator.GetAllWorkItems().OfType<IFeedback>().ToList();
                }
            }
            else if (this.CommandParameters.Count == 2)
            {
                if (this.CommandParameters[0] == "bug")
                {
                    switch (this.CommandParameters[1])
                    {
                        case "active":
                        case "fixed":
                            bugList = Validator.GetAllWorkItems().OfType<IBug>()
                                               .Where(b => b.Status.ToString().Equals(this.CommandParameters[1], StringComparison.OrdinalIgnoreCase)).ToList();
                            break;
                        default: throw new ArgumentException("Not a valid status for a bug.");
                    }
                }
                else if (this.CommandParameters[0] == "story")
                {
                    switch (this.CommandParameters[1])
                    {
                        case "notdone":
                        case "inprogress":
                        case "done":
                            storyList = Validator.GetAllWorkItems().OfType<IStory>()
                                                  .Where(s => s.StoryStatus.ToString().Equals(this.CommandParameters[1], StringComparison.OrdinalIgnoreCase)).ToList();
                            break;
                        default: throw new ArgumentException("Not a valid status for a story.");
                    }
                }
                else if (this.CommandParameters[0] == "feedback")
                {
                    switch (this.CommandParameters[1])
                    {
                        case "new":
                        case "unscheduled":
                        case "scheduled":
                        case "done":
                            feedbackList = Validator.GetAllWorkItems().OfType<IFeedback>()
                                                    .Where(f => f.FeedbackStatus.ToString().Equals(this.CommandParameters[1], StringComparison.OrdinalIgnoreCase)).ToList();
                            break;
                        default: throw new ArgumentException("Not a valid status for a feedback.");
                    }
                }
            }
            else if (this.CommandParameters.Count == 3)
            {
                if (this.CommandParameters[0] == "bug" && (this.CommandParameters[1] == "active" || this.CommandParameters[1] == "fixed"))
                {
                    bugList = Validator.GetAllWorkItems().OfType<IBug>()
                                       .Where(b => b.Status.ToString() == this.CommandParameters[1])
                                       .Where(b => b.Assignee.Equals(this.CommandParameters[2])).ToList();
                    return string.Join(" ", bugList);
                }
                else if (this.CommandParameters[0] == "story" && (this.CommandParameters[1] == "notdone" || this.CommandParameters[1] == "inprogress" || this.CommandParameters[1] == "done"))
                {
                    storyList = Validator.GetAllWorkItems().OfType<IStory>()
                                       .Where(s => s.StoryStatus.ToString() == this.CommandParameters[1])
                                       .Where(s => s.Assignee.Equals(this.CommandParameters[2])).ToList();
                    return string.Join(" ", storyList);
                }
            }

            return "1";
            if (this.CommandParameters.Count == 1)
            {
                filteredList = Validator.GetAllWorkItems().Where(GetItemList(this.CommandParameters[0])).ToList();
            }
            else if (this.CommandParameters.Count == 2) // bug new
            {
                switch (this.CommandParameters[0])
                {
                    case "bug":
                        var bugs = Validator.GetAllWorkItems().Where(GetItemList("bug")).ToList();
                        
                }
            }

            static Func<IWorkItem, bool> GetItemList(string item)
                   => item switch
                   {
                       "bug" => i => i is Bug,
                       "feedback" => i => i is Feedback,
                       "story" => i => i is Story,
                       _ => throw new ArgumentException("Not a valid filter.")
                   };
            /*static Func<IWorkItem, bool> GetByStatus(string status)
                 => status switch
                 {
                     "active" => 
                     "new" => 
                     _ => throw new ArgumentException()
                 };*/
        }
    }
}
