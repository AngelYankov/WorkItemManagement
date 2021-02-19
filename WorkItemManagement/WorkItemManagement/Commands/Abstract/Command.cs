using System.Collections.Generic;
using WorkItemManagement.Commands.Contracts;
using WorkItemManagement.Core;
using WorkItemManagement.Core.Contracts;

namespace WorkItemManagement.Commands.Abstract
{
    public abstract class Command : ICommand
    {
        protected Command() { }
        protected Command(IList<string> commandParameters,IDatabase database,IFactory factory)
        {
            this.CommandParameters = new List<string>(commandParameters);
            this.Database = database;
            this.Factory = factory;
        }
        public abstract string Execute();

        protected IList<string> CommandParameters
        {
            get;
        }

        protected IDatabase Database
        {
            get; 
        }

        protected IFactory Factory
        {
            get;
        }
        
              
    }
}
