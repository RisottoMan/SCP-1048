using System;
using Exiled.API.Features;
using Exiled.CustomRoles.API;
using Config = Scp1048.Configs.Config;

namespace Scp1048;

public class Plugin : Plugin<Config>
{
    public override string Name => "Scp1048";
    public override string Author => "RisottoMan";
    public override Version Version => new(1, 0, 0);
    public override Version RequiredExiledVersion => new(9, 6, 0);
    
    public static Plugin Singleton;
    public override void OnEnabled()
    {
        Singleton = this;
        
        // Setup the RoleAPI
        if (!RoleAPI.Startup.SetupAPI(this.Name))
            return;
        
        // Register the custom role
        Config.Scp1048RoleConfig.Register();
        
        new EventHandler();
        
        base.OnEnabled();
    }
}