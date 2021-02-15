using System;
using System.Collections.Generic;
using WorkItemManagement.Models.Contracts;

namespace WorkItemManagement.Models.WorkItems
{
    public class Team : ITeam
    {
        private readonly string name;
        private readonly IList<IMember> members = new List<IMember>();
        private readonly IList<IBoard> boards = new List<IBoard>();
        public Team(string name)
        {
            EnsureNameIsValid(name);
            this.name = name;
        }
        public string Name { get => this.name; }
        public IList<IMember> Members { get => this.members; }
        public IList<IBoard> Boards { get => this.boards; }
        private void EnsureNameIsValid(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException();
            }
            if (name.Length < 3 || name.Length > 10)
            {
                throw new ArgumentException("Team name should be between 3 and 10 characters.");
            }
        }
        /// <summary>
        /// Add board to the Team's boards
        /// </summary>
        /// <param name="board">Board to be added</param>
        public void AddBoard(IBoard board)
        {
            this.boards.Add(board);
        }
        /// <summary>
        /// Add member to the Team's members
        /// </summary>
        /// <param name="member">Member to be added</param>
        public void AddMember(IMember member)
        {
            this.members.Add(member);
        }
    }
}
