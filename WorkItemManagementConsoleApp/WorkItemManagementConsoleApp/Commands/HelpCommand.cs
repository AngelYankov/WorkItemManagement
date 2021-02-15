using System.IO;
using WorkItemManagementConsoleApp.Commands.Abstract;

namespace WorkItemManagementConsoleApp.Commands
{
    class HelpCommand : Command
    {
        public HelpCommand() : base()
        {
        }
        public override string Execute()
        {
            var reader = new StreamReader(@"....\..\..\..\..\..\CommandHelper.txt");
            return reader.ReadToEnd();

        }
    }
}
