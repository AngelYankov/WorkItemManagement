using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using WorkItemManagementConsoleApp.Commands.Abstract;

namespace WorkItemManagementConsoleApp.Commands
{
    class HelpCommand : Command
    {
        public HelpCommand() : base()
        {
        }
        public override string Execute()
        {
            
            var url = "https://file.io/fTG7w26T3C7s";//Paste ur url here  

            WebRequest request = HttpWebRequest.Create(url);

            WebResponse response = request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());

            string responseText = reader.ReadToEnd();

            //if your response is in json format just uncomment below line  

            //Response.AddHeader("Content-type", "text/json");  

            return responseText;

        }
    }
}
