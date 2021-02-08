using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Commands.Contracts;
using WorkItemManagementConsoleApp.Core.Contracts;

namespace WorkItemManagementConsoleApp.Commands.Abstract
{
    public abstract class Command : ICommand
    {
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
