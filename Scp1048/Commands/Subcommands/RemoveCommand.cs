using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.CustomRoles.API.Features;
using Scp1048.Features;

namespace Scp1048.Commands.Subcommands;

public class RemoveCommand : ICommand
{
    public string Command => "remove";
    public string Description => "Remove a custom role SCP-1048 for player";
    public string[] Aliases => [];
    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        if (arguments.Count != 1)
        {
            response = $"Specify the player id to the command: scp1048 remove [id]";
            return false;
        }
        
        Player player = Player.Get(arguments.At(0));
        if (player == null)
        {
            response = $"Player not found: {arguments.At(0)}";
            return false;
        }
        
        var role = CustomRole.Get(typeof(Scp1048Role));
        if (role == null)
        {
            response = "Custom role SCP-1048 not found or not registered";
            return false;
        }
        
        if (!role.Check(player))
        {
            response = "The player does not have the custom role SCP-1048";
            return false;
        }
        
        role.RemoveRole(player);
        response = $"<color=green>Custom role SCP-1048 removed for {player.Nickname}</color>";
        return true;
    }
}