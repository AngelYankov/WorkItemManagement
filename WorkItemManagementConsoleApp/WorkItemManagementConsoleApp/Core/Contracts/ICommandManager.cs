using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Commands.Contracts;

namespace WorkItemManagementConsoleApp.Core.Contracts
{
    public interface ICommandManager
    {
        ICommand ParseCommand(string command);
    }
}
