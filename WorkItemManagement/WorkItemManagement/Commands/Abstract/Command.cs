using System.Collections.Generic;
using WorkItemManagement.Commands.Contracts;
using WorkItemManagement.Core.Contracts;

namespace WorkItemManagement.Commands.Abstract
{
    public abstract class Command : ICommand
    {
        protected Command() { }
        protected Command(IList<string> commandParameters)
        {
            this.CommandParameters = new List<string>(commandParameters);
        }
        public abstract string Execute();

        protected IList<string> CommandParameters
        {
            get;
        }

        protected IDatabase Database
        {
            get => Core.Database.Instance;
        }

        protected IFactory Factory
        {
            get => Core.Factory.Instance;
        }
              
    }
}
