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
        public Story(string id,string title, string description, Member assignee, PriorityType priority, StoryStatusType storyStatus, SizeType size)
            : base(id, title, description)
        {
            this.Assignee = assignee;
        }

        public Member Assignee { get; }

        public PriorityType Priority { get; }

        public StoryStatusType StoryStatus { get; }
        public SizeType Size { get; }

        //Change Priority/Size/Status of a story
    }
}
