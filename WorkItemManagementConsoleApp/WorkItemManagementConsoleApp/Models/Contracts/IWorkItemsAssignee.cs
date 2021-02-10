using System;
using System.Collections.Generic;
using System.Text;

namespace WorkItemManagementConsoleApp.Models.Contracts
{
    public interface IWorkItemsAssignee
    {
        void AddAssignee(IMember member);
    }
}
