using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Core.Contracts;
using WorkItemManagementConsoleApp.Models.Contracts;
using WorkItemManagementConsoleApp.Models.Enums;
using WorkItemManagementConsoleApp.Models.WorkItems;

namespace WorkItemManagementConsoleApp.Core
{
    public class Factory : IFactory
    {
        private static IFactory instance;

        public static IFactory Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Factory();
                }
                return instance;
            }
        }
        public IBoard CreateBoard(string name)
        {
            return new Board(name);
        }

        public IBug CreateBug(string id, string title, string description, string priority, string severity, string status, Member assignee, List<string> steps)
        {
            bool success1 = Enum.TryParse(priority, true, out PriorityType priorityType);
            if (!success1)
            {
                throw new ArgumentException($"Bug priority {priority} is not valid");
            }

            bool success2 = Enum.TryParse(severity, true, out SeverityType severityType);
            if (!success2)
            {
                throw new ArgumentException($"Bug severity {severity} is not valid");
            }

            bool success3 = Enum.TryParse(status, true, out BugStatus bugStatus);
            if (!success3)
            {
                throw new ArgumentException($"Bug status {status} is not valid");
            }
            return new Bug(id, title, description, priorityType, severityType, bugStatus, assignee, steps);
        }

        public IFeedback CreateFeedback(string id, string title, string description, int rating, string status)
        {
            bool success = Enum.TryParse(status, true, out FeedbackStatusType feedbackStatus);
            if (!success)
            {
                throw new ArgumentException($"Feedback status {status} is not valid");
            }
            return new Feedback(id, title, description, rating, feedbackStatus);
        }

        public IMember CreateMember(string name)
        {
            return new Member(name);
        }

        public IStory CreateStory(string id, string title, string description, Member assignee, string priority, string storyStatus, string size)
        {
            bool success1 = Enum.TryParse(priority, true, out PriorityType priorityType);
            if (!success1)
            {
                throw new ArgumentException($"Story priority {priority} is not valid");
            }

            bool success2 = Enum.TryParse(storyStatus, true, out StoryStatusType storyStatusType);
            if (!success2)
            {
                throw new ArgumentException($"Story status {storyStatus} is not valid");
            }

            bool success3 = Enum.TryParse(size, true, out SizeType sizeType);
            if (!success3)
            {
                throw new ArgumentException($"Story size {size} is not valid");
            }
            return new Story(id, title, description, assignee, priorityType, storyStatusType, sizeType);
        }

        public ITeam CreateTeam(string name)
        {
            return new Team(name);
        }
    }
}
