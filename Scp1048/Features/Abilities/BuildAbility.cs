using Exiled.API.Features;
using RoleAPI.API.Interfaces;
using RoleAPI.API.Managers;
using UnityEngine;

namespace Scp1048.Features.Abilities;
public class BuildAbility : Ability
{
    public override string Name => "Build";
    public override string Description => "Build a new bear friend from the corpse";
    public override int KeyId => 10482;
    public override KeyCode KeyCode => KeyCode.T;
    public override float Cooldown => 10f;
    protected override void ActivateAbility(Player player, ObjectManager manager)
    {
        //manager.AudioPlayer?.AddClip($"Eric{value}");
    }
}