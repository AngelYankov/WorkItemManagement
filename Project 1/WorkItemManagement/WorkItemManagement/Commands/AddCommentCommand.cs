using System;
using System.Collections.Generic;
using System.Linq;
using WorkItemManagement.Commands.Abstract;
using WorkItemManagement.Core;
using WorkItemManagement.Core.Contracts;

namespace WorkItemManagement.Commands
{
    public class AddCommentCommand : Command
    {
        public AddCommentCommand(IList<string> commandParameters, IDatabase database, IFactory factory)
            : base(commandParameters,database,factory)
        {
        }
        public override string Execute() //addcomment id Key-Member Value-string
        {
            var validator = new Validator(Database);

            validator.ValidateParamsIfLessThan(CommandParameters, 3);
            string idWorkItem = this.CommandParameters[0];
            string memberName = this.CommandParameters[1];
            IList<string> comments = this.CommandParameters.Skip(2).ToList();

            var workItem = Database.GetWorkItem(idWorkItem);
            var member = Database.GetMember(memberName);

            validator.MemberHasWorkItem(workItem, member);
            workItem.AddComment(member, comments);
            member.AddActivityHistory($"'{memberName}' added comment to work item: '{idWorkItem}'.");

            return $"Member: '{memberName}' added comment: '{string.Join(" ", comments)}' to work item: '{idWorkItem}'";
        }
    }
}
