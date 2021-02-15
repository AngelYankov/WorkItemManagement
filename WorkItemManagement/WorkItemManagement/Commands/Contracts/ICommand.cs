using System;
using System.Collections.Generic;
using System.Text;

namespace WorkItemManagement.Commands.Contracts
{
    public interface ICommand
    {
        string Execute();
    }
}
