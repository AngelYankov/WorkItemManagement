using System;
using System.Collections.Generic;
using WorkItemManagement.Core.Contracts;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.Core
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

        public IBug CreateBug(string id, string title, string priority, string severity, List<string> steps, string description)
        {
            bool success1 = Enum.TryParse(priority, true, out PriorityType priorityType);
            if (!success1)
            {
                throw new ArgumentException($"Bug priority '{priority}' is not valid");
            }

            bool success2 = Enum.TryParse(severity, true, out SeverityType severityType);
            if (!success2)
            {
                throw new ArgumentException($"Bug severity '{severity}' is not valid");
            }

            return new Bug(id, title, priorityType, severityType, steps, description);
        }

        public IFeedback CreateFeedback(string id, string title, int rating, string description)
        {
            return new Feedback(id, title, rating, description);
        }

        public IMember CreateMember(string name)
        {
            return new Member(name);
        }

        public IStory CreateStory(string id, string title, string priority, string size, string description)
        {
            bool success1 = Enum.TryParse(priority, true, out PriorityType priorityType);
            if (!success1)
            {
                throw new ArgumentException($"Story priority '{priority}' is not valid");
            }

            bool success2 = Enum.TryParse(size, true, out SizeType sizeType);
            if (!success2)
            {
                throw new ArgumentException($"Story size '{size}' is not valid");
            }
            return new Story(id, title, priorityType, sizeType, description);
        }

        public ITeam CreateTeam(string name)
        {
            return new Team(name);
        }
    }
}
