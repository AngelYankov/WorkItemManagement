﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementConsoleApp.Commands.Abstract;
using WorkItemManagementConsoleApp.Core;
using WorkItemManagementConsoleApp.Models.Enums;
using WorkItemManagementConsoleApp.Models.WorkItems;

namespace WorkItemManagementConsoleApp.Commands
{
    public class ChangeStoryCommand : Command
    {
        public ChangeStoryCommand(IList<string> commandParameters)
            :base(commandParameters)
        {
        }
        public override string Execute() // changestory id Property type // priority/status/size
        {
            Validator.ValidateParameters(this.CommandParameters, 3);

            string id = this.CommandParameters[0];
            string property = this.CommandParameters[1];
            string type = this.CommandParameters[2];
            var story = this.Database.AllWorkItems.OfType<Story>().ToList().FirstOrDefault(s => s.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
            switch (property)
            {
                case "priority":
                    if (!Enum.TryParse(type,true, out PriorityType priority))
                    {
                        throw new ArgumentException($"'{type}' is not a valid priority type");
                    }
                    return story.ChangePriority(priority);
                case "size":
                    if (!Enum.TryParse(type, true, out SizeType size))
                    {
                        throw new ArgumentException($"'{type}' is not a valid size type");
                    }
                    return story.ChangeSize(size);
                case "status":
                    if (!Enum.TryParse(type, true, out StoryStatusType status))
                    {
                        throw new ArgumentException($"'{type}' is not a valid status type");
                    }
                    return story.ChangeStatus(status);
                default:
                    throw new ArgumentException("Property type is not valid.");
            }
        }
    }
}