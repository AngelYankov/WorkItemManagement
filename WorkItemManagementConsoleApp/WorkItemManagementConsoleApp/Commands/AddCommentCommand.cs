using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementConsoleApp.Commands.Abstract;
using WorkItemManagementConsoleApp.Core;

namespace WorkItemManagementConsoleApp.Commands
{
    public class AddCommentCommand : Command
    {
        public AddCommentCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }
        public override string Execute() //addcomment id Key-Member Value-string
        {
            Validator.ValidateParamsIfLessThan(CommandParameters, 3);
            string idWorkItem = this.CommandParameters[0];
            string memberName = this.CommandParameters[1];
            IList<string> comments = new List<string>();
            for (int i = 2; i < this.CommandParameters.Count; i++)
            {
                comments.Add(this.CommandParameters[i]);
            }

            var workItem = Validator.GetWorkItem(idWorkItem);
            var member = Validator.GetMember(memberName);
            if (!member.WorkItems.Contains(workItem))
            {
                throw new ArgumentException($"Member: '{memberName}' does not have access to work item: '{idWorkItem}'.");
            }
            workItem.AddComment(member, comments);

            return $"Member: '{memberName}' added comment: {string.Join(" ", comments)} to work item: '{idWorkItem}'";
        }
    }
}
