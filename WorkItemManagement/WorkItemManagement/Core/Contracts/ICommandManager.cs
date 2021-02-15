using WorkItemManagement.Commands.Contracts;

namespace WorkItemManagement.Core.Contracts
{
    public interface ICommandManager
    {
        ICommand ParseCommand(string command);
    }
}
