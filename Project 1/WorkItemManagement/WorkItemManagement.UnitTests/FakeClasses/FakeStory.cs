using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.Models.Enums;

namespace WorkItemManagement.UnitTests.FakeClasses
{
    public class FakeStory : IStory
    {
        private IMember assignee;
        private PriorityType priorityType;
        private StoryStatusType storyStatus;
        private SizeType sizeType;
        public FakeStory(string id)
        {
            this.Id = id;
            this.Comments = new Dictionary<IMember, IList<string>>();
            this.History = new List<string>();
            this.Title = "DefaultTitle";
        }

        public PriorityType Priority
        {
            get => this.priorityType;
            private set
            {
                this.AddHistory($"Story priority type changed from '{this.priorityType}' to '{value}'.");
                this.priorityType = value;
            }
        }

        public StoryStatusType StoryStatus
        {
            get => this.storyStatus;
            private set
            {
                this.AddHistory($"Story status type changed from '{this.storyStatus}' to '{value}'.");
                this.storyStatus = value;
            }
        }
        public SizeType Size
        {
            get => this.sizeType;
            private set
            {
                this.AddHistory($"Story size changed from '{this.sizeType}' to '{value}'.");
                this.sizeType = value;
            }
        }
        public IMember Assignee
        {
            get => this.assignee;
            private set
            {
                if (this.assignee == null)
                {
                    this.AddHistory($"Story assigned to '{value.Name}'.");
                }
                else
                {
                    if (value == null)
                    {
                        this.AddHistory($"Story assignee removed.");
                    }
                    else
                    {
                        this.AddHistory($"Story assignee changed from '{this.assignee.Name}' to '{value.Name}'.");
                    }
                }
                this.assignee = value;
            }
        }

        public string Id { get; set; }

        public string Title {get; set;}

        public string Description { get; set; }

        public IDictionary<IMember, IList<string>> Comments { get; set; }

        public IList<string> History { get; set; }

        public void AddAssignee(IMember member)
        {
            if (this.Assignee == member)
            {
                throw new ArgumentException($"Story already assigned to '{member.Name}'");
            }
            this.Assignee = member;
        }
        public void RemoveAssignee()
        {
            if (this.Assignee == null)
            {
                throw new ArgumentException($"Story has no assignee.");
            }
            this.Assignee = null;
        }
        public IMember GetAssignee()
        {
            if (this.Assignee == null)
            {
                throw new ArgumentException("There is no assignee.");
            }
            return this.Assignee;
        }
        public string ChangePriority(PriorityType priority)
        {
            if (this.Priority == priority)
            {
                throw new ArgumentException($"Priority already at '{priority}'.");
            }
            this.Priority = priority;
            return $"Story priority changed to '{priority}'.";
        }
        public string ChangeSize(SizeType size)
        {
            if (this.Size == size)
            {
                throw new ArgumentException($"Size already at '{size}'.");
            }
            this.Size = size;
            return $"Story size changed to '{size}'.";
        }
        public string ChangeStatus(StoryStatusType status)
        {
            if (this.StoryStatus == status)
            {
                throw new ArgumentException($"Status already at '{status}'.");
            }
            this.StoryStatus = status;
            return $"Story status changed to '{status}'.";
        }

        public override string ToString()
        {
            string history = this.History.Count == 0 ? "No history" : string.Join(" ", this.History);
            string comments = this.Comments.Count == 0 ? "No comments" : string.Join(" ", this.Comments);
            string assigneetext = this.Assignee == null ? "No assignee" : this.Assignee.Name;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Story ----");
            sb.AppendLine($"ID: {this.Id}");
            sb.AppendLine($"Title: {this.Title}");
            sb.AppendLine($"Description: {this.Description}");
            sb.AppendLine($"Activity history: {history}");
            sb.AppendLine($"Comments: {comments}");
            sb.AppendLine($"Priority: {this.priorityType}");
            sb.AppendLine($"Status: {this.storyStatus}");
            sb.AppendLine($"Size: {this.sizeType}");
            sb.AppendLine($"Assignee: {assigneetext}");

            return sb.ToString().Trim();
        }

        public void AddHistory(string info)
        {
            this.History.Add(info);
        }

        public void AddComment(IMember member, IList<string> comments)
        {
            this.Comments.Add(member, comments);
        }
    }
}
