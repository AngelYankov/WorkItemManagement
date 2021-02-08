using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Models.Contracts;

namespace WorkItemManagementConsoleApp.Models.WorkItems
{
    public class Member : IMember
    {
        private string name;
        public Member(string name)
        {
            this.Name = name;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Length < 5 || value.Length > 15)
                {
                    throw new ArgumentException("Member name should be between 5 and 15 characters.");
                }
                this.name = value;
            }
        }
        public List<IWorkItem> WorkItems { get; }
        public List<string> ActivityHistory { get; }

        //add workitems and activityhistory - methods
        //Assign/Unassign work item to a person
    }
}
