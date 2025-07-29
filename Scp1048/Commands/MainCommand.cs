using System;
using CommandSystem;
using Exiled.Permissions.Extensions;
using Scp1048.Commands.Subcommands;

namespace Scp1048.Commands;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
[CommandHandler(typeof(GameConsoleCommandHandler))]
public class MainCommand : ParentCommand
{
    public override string Command => "scp1048";
    public override string Description => "Give for player custom role SCP-1048";
    public override string[] Aliases => [];
    public MainCommand() => LoadGeneratedCommands();
    public override void LoadGeneratedCommands()
    {
        RegisterCommand(new GiveCommand());
        RegisterCommand(new RemoveCommand());
    }
    
    protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        if (!((CommandSender)sender).CheckPermission(".scp1048"))
        {
            response = "You do not have permission to use this command!";
            return false;
        }

        response = "Please enter a valid subcommand: give, remove";
        return false;
    }
}