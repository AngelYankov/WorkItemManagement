using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementConsoleApp.Commands.Abstract;

namespace WorkItemManagementConsoleApp.Commands
{
    public class CreateBugCommand : Command
    {
        public CreateBugCommand(IList<string> commandParameters)
            :base(commandParameters)
        {

        }

        public override string Execute()
        {
            if(this.CommandParameters.Count < 9)
            {
                throw new ArgumentException("Parameters count is not valid.");
            }

            string boardName = this.CommandParameters[0];
            string teamName = this.CommandParameters[1];
            string id = this.CommandParameters[2];
            string title = this.CommandParameters[3];
            string description = this.CommandParameters[4];
            string priority = this.CommandParameters[5];
            string severity = this.CommandParameters[6];
            string status = this.CommandParameters[7];
            string assignee = this.CommandParameters[8];
            List<string> steps = this.CommandParameters[9].Split(",").ToList();

            int boardIndex = teamName
        }
    }
}
