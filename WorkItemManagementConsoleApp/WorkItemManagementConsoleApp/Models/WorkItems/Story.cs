using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Models.Enums;
using WorkItemManagementConsoleApp.Models.Contracts;
using WorkItemManagementConsoleApp.Models.Abstract;

namespace WorkItemManagementConsoleApp.Models.WorkItems
{
    public class Story : WorkItem, IStory
    {
        private Member assignee;

        public Story(int Id, string title, string description, IDictionary<string, List<string>> comments, List<string> history, Member assignee, PriorityType priority, StoryStatusType storyStatus, SizeType size)
            : base( title, description, /*comments*/ history)
        {
            this.Assignee = assignee;
        }

        public Member Assignee { get; set; }

        public PriorityType Priority { get; }

        public StoryStatusType StoryStatus { get; }
        public SizeType Size { get; }

        /*public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Story ----");
            sb.AppendLine($"{this.base}");
            sb.AppendLine($"Assignee: {Priority}");
            sb.AppendLine($"Priority: {StoryStatus}");
            sb.AppendLine($"Status: {StoryStatus}");
            sb.AppendLine($"Size: {Size}");

            return sb.ToString();
        }*/
    }
}
