using System.IO;
using WorkItemManagement.Commands.Abstract;

namespace WorkItemManagement.Commands
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
