using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Models.Contracts;

namespace WorkItemManagementConsoleApp.Models.WorkItems
{
    public class Member : IMember
    {
        private string name;

        public Member(string name, List<IWorkItem> workItems, List<string> activityHistory, List<string> existingMembers)
        {
            this.Name = name;
            this.WorkItems = workItems;
            this.ActivityHistory = activityHistory;
            this.ExistingMembers = existingMembers;
        }
        public string Name
        {
            get => this.name;
            set
            {
                if(value.Length < 5 || value.Length > 15)
                {
                    throw new ArgumentOutOfRangeException("Name should be between 5 and 15 symbols.");
                }
                if (ExistingMembers.Contains(value))
                {
                    throw new ArgumentException("Member already exists!");
                }
                this.name = value;
            }
        }
        public List<IWorkItem> WorkItems { get; set ; }
        public List<string> ActivityHistory { get ; set ; }
        public List<string> ExistingMembers { get; set; }
    }
}
