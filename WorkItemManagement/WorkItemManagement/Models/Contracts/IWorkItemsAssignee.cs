namespace WorkItemManagement.Models.Contracts
{
    public interface IWorkItemsAssignee
    {
        void AddAssignee(IMember member);

        void RemoveAssignee();

        IMember GetAssignee();
    }
}
