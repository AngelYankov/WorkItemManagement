using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Contracts;

namespace WorkItemManagement.Core.Contracts
{
    public interface IValidator
    {
        void ValidateParameters(IList<string> parameters, int n);

        void ValidateParamsIfLessThan(IList<string> parameters, int n);

        void MemberExistsInTeam(string name, ITeam team);

        void BoardExistsInTeam(string name, ITeam team);

        void TeamExists(string name);

        void MemberExists(string name);

        void MemberExistsInAnyTeam(string name);

        void MemberHasWorkItem(IWorkItem workItem, IMember member);
       

    }
}
