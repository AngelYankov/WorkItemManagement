﻿using System;
using System.Collections.Generic;
using System.Linq;
using WorkItemManagement.Commands.Abstract;
using WorkItemManagement.Core;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.Commands
{
    public class ChangeBugCommand : Command
    {
        public ChangeBugCommand(IList<string> commandParameters)
            : base(commandParameters)
        {

        }

        public override string Execute() // changebug id severity major
        {
            Validator.ValidateParameters(this.CommandParameters, 3);

            string id = this.CommandParameters[0];
            string property = this.CommandParameters[1];
            string type = this.CommandParameters[2];

            var bug = Database.GetAllWorkItems().OfType<Bug>().ToList().FirstOrDefault(b => b.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
           
            if (bug == null)
            {
                throw new ArgumentException($"Bug: '{id}' does not exist");
            }
            switch (property)
            {
                case "priority":
                    if (!Enum.TryParse(type, true, out PriorityType priorityType))
                    {
                        throw new ArgumentException($"'{type}' is not a valid priority type");
                    }
                    return bug.ChangePriority(priorityType);
                case "severity":
                    if (!Enum.TryParse(type, true, out SeverityType severityType))
                    {
                        throw new ArgumentException($"'{type}' is not a valid severity type");
                    }
                    return bug.ChangeSeverity(severityType);
                case "status":
                    if (!Enum.TryParse(type, true, out BugStatus bugStatus))
                    {
                        throw new ArgumentException($"'{type}' is not a valid status type");
                    }
                    return bug.ChangeStatus(bugStatus);
                default:
                    throw new ArgumentException("Property type is not valid.");
            }
        }
    }
}
