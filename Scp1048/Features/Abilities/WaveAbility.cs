using System.Collections.Generic;
using CustomPlayerEffects;
using Exiled.API.Features;
using MEC;
using RoleAPI.API.Interfaces;
using RoleAPI.API.Managers;
using UnityEngine;

namespace Scp1048.Features.Abilities;
public class WaveAbility : Ability
{
    public override string Name => "Wave";
    public override string Description => "Wave your paw at the players";
    public override int KeyId => 10481;
    public override KeyCode KeyCode => KeyCode.R;
    public override float Cooldown => 15f;
    protected override void ActivateAbility(Player player, ObjectManager manager)
    {
        player.EnableEffect<Ensnared>(5f);
        manager.Animator?.Play("WaveAnimation");
        Timing.RunCoroutine(this.CheckEndOfAnimation(player, manager));
    }
    
    private IEnumerator<float> CheckEndOfAnimation(Player player, ObjectManager manager)
    {
        yield return Timing.WaitForSeconds(0.1f);
        string initialClipName = manager.Animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        
        while (true)
        {
            var clipInfo = manager.Animator.GetCurrentAnimatorClipInfo(0);
            if (clipInfo[0].clip.name != initialClipName)
            {
                player.DisableEffect<Ensnared>();
                yield break;
            }
            
            yield return Timing.WaitForSeconds(0.5f);
        }
    }
}