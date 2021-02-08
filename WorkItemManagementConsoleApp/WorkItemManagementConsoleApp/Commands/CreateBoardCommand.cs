using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementConsoleApp.Commands.Abstract;
using WorkItemManagementConsoleApp.Models.Contracts;

namespace WorkItemManagementConsoleApp.Commands
{
    public class CreateBoardCommand : Command
    {
        public CreateBoardCommand(IList<string> commandParameters)
            :base(commandParameters)
        {

        }

        public override string Execute()
        {
            if(this.CommandParameters.Count > 2)
            {
                throw new ArgumentException("Parameters count is not valid");
            }

            string name = this.CommandParameters[0];
            string teamName = this.CommandParameters[1];
            int indexExistingTeam = 0;
            bool teamExist = false;

            for (int i = 0; i < this.Database.AllTeams.Count; i++)
            {
                if(this.Database.AllTeams[i].Name.Equals(teamName, StringComparison.OrdinalIgnoreCase))
                {
                    indexExistingTeam = i;
                    teamExist = true;
                    break;
                }
            }

            if (!teamExist)
            {
                throw new ArgumentException("Team does not exist!");
            }

           

            IBoard board = this.Factory.CreateBoard(name);

            this.Database.AllTeams[indexExistingTeam].Boards.Add(board);
        }
    }
}
