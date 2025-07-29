using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using MEC;
using PlayerStatsSystem;
using RoleAPI.API.Interfaces;
using RoleAPI.API.Managers;
using UnityEngine;

namespace Scp1048.Features.Abilities;
public class ShriekAbility : Ability
{
    public override string Name => "Shriek";
    public override string Description => "Plays Shriek, which kills players";
    public override int KeyId => 10480;
    public override KeyCode KeyCode => KeyCode.F;
    public override float Cooldown => 40f;
    protected override void ActivateAbility(Player player, ObjectManager manager)
    {
        if (manager.AudioPlayer is null)
            return;
        
        manager.AudioPlayer.AddClip("Shriek");
        Timing.RunCoroutine(CheckEndOfPlayback(player, manager));
    }
    
    private IEnumerator<float> CheckEndOfPlayback(Player scp, ObjectManager manager)
    {
        float distance = Plugin.Singleton.Config.Distance;
        float damage = Plugin.Singleton.Config.Damage;
        string damageText = Plugin.Singleton.Config.Scp1048RoleConfig.CustomDeathText;
        bool isBreakableWindows = Plugin.Singleton.Config.IsBreakableWindows;

        if (distance <= 0 || damage <= 0)
            yield break;

        float maxWaitForStart = 2f;
        float waited = 0f;
        
        // This is a test cycle in case the sound doesn't work.
        while (manager.AudioPlayer.ClipsById.Values.Any(clip => clip.Clip != "Shriek"))
        {
            if (waited > maxWaitForStart)
                yield break;
            
            yield return Timing.WaitForSeconds(0.1f);
            waited += 0.1f;
        }
        
        // While the sound is running
        while (manager.AudioPlayer.ClipsById.Values.Any(clip => clip.Clip == "Shriek"))
        {
            // Can break the windows
            if (isBreakableWindows is true)
            {
                foreach (var window in Window.List)
                {
                    if (Vector3.Distance(scp.Position, window.Position) <= distance && !window.IsBroken)
                    {
                        window.BreakWindow();
                    }
                }
            }
            
            // Deal damage to players near SCP
            foreach (Player player in Player.List)
            {
                if (player == scp || player.IsDead || player.IsScp)
                    continue;
                
                if (Vector3.Distance(scp.Position, player.Position) <= distance)
                {
                    // add effect
                    player.Hurt(new CustomReasonDamageHandler(damageText, damage));
                }
            }
            
            yield return Timing.WaitForSeconds(0.5f);
        }
    }
}