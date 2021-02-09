using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementConsoleApp.Models.Contracts;

namespace WorkItemManagementConsoleApp.Core
{
    public static class Validator
    {
        public static void ValidateParameters(IList<string> parameters,int n)
        {
            if (parameters.Count != n)
            {
                throw new ArgumentException("Parameters count is not valid");
            }
        }
        public static void ValidateParamsIfLessThan(IList<string> parameters, int n)
        {
            if (parameters.Count < n)
            {
                throw new ArgumentException("Parameters count is not valid");
            }
        }
        public static void TeamExists(string name)
        {
            bool teamExists = Database.Instance.AllTeams.Any(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (teamExists)
            {
                throw new ArgumentException($"Team: '{name}' already exists");
            }
        } 
        public static void MemberExists(string name)
        {
            bool nameExists = Database.Instance.AllMembers.Any(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (nameExists)
            {
                throw new ArgumentException($"Member: '{name}' already exists.");
            }
        }
        public static void BoardExists(string name,ITeam team)
        {
            var boardExists = team.Boards.Any(b => b.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (boardExists)
            {
                throw new ArgumentException($"Board: '{name}' already exists in team: '{team.Name}'");
            }
        }
        public static ITeam GetTeam(string name)
        {
            var team = Database.Instance.AllTeams.FirstOrDefault(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (team == null)
            {
                throw new ArgumentException($"Team: '{name}' does not exist.");
            }
            return team;
        }
        public static IBoard GetBoard(string name,ITeam team)
        {
            var existingBoard = team.Boards.FirstOrDefault(b => b.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (existingBoard == null)
            {
                throw new ArgumentException($"Board: '{name}' does not exist in team:'{team.Name}'.");
            }
            return existingBoard;
        }

    }
}
