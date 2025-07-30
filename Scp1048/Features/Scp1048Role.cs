using System.Collections.Generic;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Spawn;
using PlayerRoles;
using RoleAPI.API;
using RoleAPI.API.Configs;
using Scp1048.Features.Abilities;
using UnityEngine;

namespace Scp1048.Features;

public class Scp1048Role : ExtendedRole
{
    public override string Name { get; set; } = "SCP-1048";
    public override string Description { get; set; } = "Builder Bear";
    public override string CustomInfo { get; set; } = "SCP-1048";
    public override uint Id { get; set; } = 1048;
    public override int MaxHealth { get; set; } = 2000;
    public override SpawnProperties SpawnProperties { get; set; } = new()
    {
        Limit = 1,
        DynamicSpawnPoints = [new DynamicSpawnPoint { Chance = 100, Location = SpawnLocationType.Inside939Cryo }]
    };
    
    public override RoleTypeId Role { get; set; } = RoleTypeId.Scp0492;
    
    public override Exiled.API.Features.Broadcast Broadcast { get; set; } = new()
    {
        Show = true,
        Content = 
            "<color=red>\ud83c\udfb5 You are SCP-1048 - Builder Bear \ud83c\udfb5\n" +
            "Build your brother SCP-1048-A to kill humans\n" +
            "Use abilities by clicking on the buttons</color>",
        Duration = 15
    };
    
    public override string ConsoleMessage { get; set; } =
        "You are SCP-1048 - Builder Bear!\n" +
        "Build your brother SCP-1048-A to kill humans\n" +
        "Configure your buttons in the settings. Remove the stars.";

    public override string CustomDeathText { get; set; } = "<color=red>Asphyxiation caused by an abundance of the ear-like growths by SCP-1048</color>";
    
    public override string CassieDeathAnnouncement { get; set; } = "SCP-1048 contained successfully.";
    
    public override SpawnConfig SpawnConfig { get; set; } = new()
    {
        MinPlayers = 10,
        SpawnChance = 30
    };
    
    public override SchematicConfig SchematicConfig { get; set; } = new()
    {
        SchematicName = "Scp1048",
        Offset = new Vector3(0f, -0.95f, 0f),
    };
    
    public override TextToyConfig TextToyConfig { get; set; } = new()
    {
        Text = "<color=red>SCP-1048</color>",
        Offset = new Vector3(0, 1, 0),
        Rotation = new Vector3(0, 180, 0),
        Scale = new Vector3(0.15f, 0.15f, 0.15f),
    };

    public override HintConfig HintConfig { get; set; } = new()
    {
        Text = "<align=right><size=50><color=red><b>SCP-1048</b></color></size>\n" + 
               "<size=30><color=red>Build your bear brothers!</color></size>\n\n" + 
               "Abilities:\n" + 
               "<color=%color%>Shriek {0}</color>\n" + 
               "<color=%color%>Wave paw {1}</color>\n" + 
               "<color=%color%>Build bear {2}</color>\n" + 
               "\n<size=18>find a corpse to create bear brother</size></align>",
        AvailableAbilityColor = "red",
        UnavailableAbilityColor = "#880000"
    };
    
    public override AudioConfig AudioConfig { get; set; } = new()
    {
        Name = "scp1048",
        Volume = 100,
        IsSpatial = true,
        MinDistance = 5f,
        MaxDistance = 15f
    };

    public override AbilityConfig AbilityConfig { get; set; } = new()
    {
        AbilityTypes = 
        [
            typeof(ShriekAbility),
            typeof(WaveAbility),
            typeof(BuildAbility)
        ]
    };

    public override List<EffectConfig> Effects { get; set; } =
    [
        new EffectConfig()
        {
            EffectType = EffectType.Disabled,
        },

        new EffectConfig()
        {
            EffectType = EffectType.Slowness,
            Intensity = 10 //?
        },
        
        new EffectConfig()
        {
            EffectType = EffectType.SilentWalk,
            Intensity = 50
        }
    ];
    
    public override bool IsPlayerInvisible { get; set; } = true;
    public override bool IsShowPlayerNickname { get; set; } = true;

    public override void AddRole(Player player)
    {
        base.AddRole(player);
        player.GameObject.AddComponent<AnimationComponent>();
    }

    public override void RemoveRole(Player player)
    {
        base.RemoveRole(player);
        if (player is null) return;
        
        var animationComponent = player.GameObject.GetComponent<AnimationComponent>();
        UnityEngine.Object.Destroy(animationComponent);
    }
}