namespace SCP_List.Commands
{
    using System;
    using System.Collections.Generic;
    using CommandSystem;
    using Exiled.API.Features;
    using Exiled.Permissions.Extensions;
    using RemoteAdmin;
    
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Scplist : ICommand
    {
        public string Command { get; } = "scplist";

        public string[] Aliases { get; } = new string[] { "listscp" };

        public string Description { get; } = "List all scps";

        private Player _player;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender is PlayerCommandSender player)
            {
                _player = new Player(player.ReferenceHub);
            }
        
            if (!((CommandSender)sender).CheckPermission("scplist.use"))
            {
                response = "You do not have permission to use this command!";
                return false;
            }
            
            var scpList = new List<string>();

            foreach (var ply in Player.List)
            {
                if (ply.Team == Team.SCP)
                {
                    if (ply.SessionVariables.ContainsKey("IsNPC")) continue;
                    scpList.Add($"<color=green>{ply.Nickname}</color> - <color=white>({ply.Role})</color>");
                }
                else if (ply.SessionVariables.ContainsKey("IsScp035"))
                {
                    scpList.Add($"<color=green>{ply.Nickname}</color> - <color=white>({ply.Role})[<color=red>Scp035</color>]</color>");
                }
            }
            
            if (_player.Team == Team.SCP || scpList.Contains($"<color=green>{_player.Nickname}</color> - <color=white>({_player.Role})[<color=red>Scp035</color>]</color>"))
            {
                var scpListCombined = string.Join(",\n", scpList.ToArray());
                if (scpList.Count == 0)
                {
                    response = "\n<color=red><size=30>There are no SCPs!</size></color>";
                    return true;
                }

                response = "\n<color=red><size=30>List of SCPs:</size></color>\n" +
                           scpListCombined;
                return true;
                

            }
            
            response = "You are not an SCP!";
            return false;
        }
    }
}