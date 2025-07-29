using System.ComponentModel;
using Exiled.API.Interfaces;
using Scp1048.Features;

namespace Scp1048.Configs;
public class Config : IConfig
{
    [Description("Whether or not is the plugin enabled?")]
    public bool IsEnabled { get; set; } = true;

    [Description("Whether or not is the plugin is in debug mode?")]
    public bool Debug { get; set; } = false;
    
    [Description("Maximum range of SCP-1048 abilities")]
    public float Distance { get; set; } = 5;
    
    [Description("How much damage should SCP-1048 do?")]
    public float Damage { get; set; } = 3;

    [Description("Can SCP-066 destroy windows with its Noise ability?")]
    public bool IsBreakableWindows { get; set; } = true;

    [Description("Configs for the Custom role players turn into")]
    public Scp1048Role Scp1048RoleConfig { get; set; } = new();
}