using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Common;
using WorkItemManagementConsoleApp.WorkItem.Contracts;

namespace WorkItemManagementConsoleApp.WorkItem.WorkItems
{
    class Story : WorkItem, IStory
    {
        private Member assignee;

        public Feedback(int Id, string title, string description, IDictionary<string, List<string>> comments, List<string> history, Member assignee, PriorityType priority, StoryStatusType storyStatus, SizeType size)
            : base(int Id, string title, string description, IDictionary<string, List<string>> comments, List<string> history)
        {
            this.Assignee = assignee;
        }

        public Member Assignee { get; set; }

        public PriorityType Priority { get; }

        public StoryStatusType StoryStatus { get; }
        public SizeType Size { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Story ----");
            sb.AppendLine($"{this.base}");
            sb.AppendLine($"Assignee: {Priority}");
            sb.AppendLine($"Priority: {StoryStatus}");
            sb.AppendLine($"Status: {StoryStatus}");
            sb.AppendLine($"Size: {Size}");

            return sb.ToString();
        }
    }
}
