using System;
using System.Collections.Generic;
using System.Linq;
using WorkItemManagement.Commands.Abstract;
using WorkItemManagement.Core;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.Commands
{
    public class ChangeFeedbackCommand : Command
    {
        public ChangeFeedbackCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }
        public override string Execute() //changefeedback id Property type 
        {
            Validator.ValidateParameters(this.CommandParameters, 3);

            string id = this.CommandParameters[0];
            string property = this.CommandParameters[1];
            string type = this.CommandParameters[2];

            var feedback = Validator.GetAllWorkItems(Database).OfType<Feedback>().ToList().FirstOrDefault(f => f.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
            if (feedback == null)
            {
                throw new ArgumentException($"Feedback: '{id}' does not exist.");
            }
            switch (property)
            {
                case "status":
                    if (!Enum.TryParse(type, true, out FeedbackStatusType statusType))
                    {
                        throw new ArgumentException($"'{type}' is not a valid status type.");
                    }
                    return feedback.ChangeStatus(statusType);
                case "rating":
                    if (!int.TryParse(type, out int rating))
                    {
                        throw new ArgumentException("Rating should be a number.");
                    }
                    if (rating < 1 || rating > 10)
                    {
                        throw new ArgumentException($"Rating '{type}' should be between 1 an 10.");
                    }
                    return feedback.ChangeRating(rating);
                default:
                    throw new ArgumentException("Property type is not valid.");
            }
        }
    }
}
