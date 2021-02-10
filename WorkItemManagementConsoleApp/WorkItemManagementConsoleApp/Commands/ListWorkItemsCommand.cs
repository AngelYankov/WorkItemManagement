
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementConsoleApp.Commands.Abstract;
using WorkItemManagementConsoleApp.Core;
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
            StringBuilder sb = new StringBuilder();
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
            return sb.ToString();
        }
    }
}
