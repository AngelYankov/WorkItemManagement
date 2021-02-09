
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementConsoleApp.Commands.Abstract;
using WorkItemManagementConsoleApp.Models.WorkItems;

namespace WorkItemManagementConsoleApp.Commands
{
    public class ListWorkItemsCommand : Command
    {
        public ListWorkItemsCommand(IList<string> commandParameters)
            : base(commandParameters)
        {

        }

        public override string Execute() // listworkitems bug
        {
            if (CommandParameters.Count != 1)
            {
                throw new ArgumentException("Parameters count is not valid");
            }

            string items = CommandParameters[0];
            StringBuilder sb = new StringBuilder();

            this.Database.AllWorkItems.Where(b => b is Bug).ToList().ForEach(b => sb.AppendLine(b.ToString()));
            return sb.ToString().Trim();
        }
    }
}
