using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Commands.Abstract;

namespace WorkItemManagementConsoleApp.Commands
{
    class ShowBoardActivityCommand : Command
    {
        public ShowBoardActivityCommand(IList<string> commandParameters)
            :base(commandParameters)
        {

        }

        public override string Execute()
        {
            throw new NotImplementedException();
        }
    }
}
