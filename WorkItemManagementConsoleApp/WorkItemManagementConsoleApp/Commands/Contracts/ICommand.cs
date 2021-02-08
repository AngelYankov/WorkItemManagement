using System;
using System.Collections.Generic;
using System.Text;

namespace WorkItemManagementConsoleApp.Commands.Contracts
{
    public interface ICommand
    {
        string Execute();
    }
}
