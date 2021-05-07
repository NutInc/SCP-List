using System;
using System.Collections.Generic;
using CommandSystem;
using RemoteAdmin;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;

namespace SCPList.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Scplist : ICommand
    {
        public string Command { get; } = "scplist";

        public string[] Aliases { get; } = new string[] { "listscp" };

        public string Description { get; } = "List all scps";


    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {

            if (!((CommandSender)sender).CheckPermission("scplist.use"))
            {
                response = "You do not have permission to use this command!";
                return false;
            } else
            {
                List<string> ListOfSCPs = new List<string>();

                foreach (Player ply in Player.List)
                {
                    if (ply.Team == Team.SCP)
                    {
                        if (ply.SessionVariables.ContainsKey("IsNPC")) continue;
                        ListOfSCPs.Add($"<color=green>{ply.Nickname}</color> - <color=white>({ply.Role})</color>");
                    }
                }

                string ListOfSCPsCombined = string.Join(",\n", ListOfSCPs.ToArray());
                if (ListOfSCPs.Count == 0)
                {
                    response = "\n<color=red><size=30>There are no SCPs!</size></color>";
                    return true;
                }
                else
                {
                    response = $"\n<color=red><size=30>List of SCPS:</size></color>\n" +
                    $"{ListOfSCPsCombined}";
                    return true;
                }
                
            }
        }
    }
}
