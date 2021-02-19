using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Contracts;

namespace WorkItemManagement.UnitTests.FakeClasses
{
    public class FakeTeam : ITeam
    {
        public FakeTeam() 
        {
            this.Boards = new List<IBoard>();
            this.Members = new List<IMember>();
        }

        public FakeTeam(string name)
        {
            this.Name = name;
            this.Boards = new List<IBoard>();
            this.Members = new List<IMember>();
        }
        public string Name { get; set; }

        public IList<IMember> Members { get; }

        public IList<IBoard> Boards { get; }

        public void AddBoard(IBoard board)
        {
            this.Boards.Add(board);
        }

        public void AddMember(IMember member)
        {
            this.Members.Add(member);
        }
    }
}
