using Exiled.API.Features;
using UnityEngine;

namespace Scp1048.Features;
public class AnimationComponent : MonoBehaviour
{
    private Player _player;
    private Animator _animator;
    private bool _isJumping;
    private bool _isWalking;
    
    public void Awake()
    {
        _player = Player.Get(gameObject);
    }

    public void Update()
    {
        _isJumping = _player.IsJumping;
        _isWalking = _player.Velocity.magnitude > 0;
        var stateInfo = _animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.normalizedTime < 1f || stateInfo.IsName("JumpAnimation"))
            return;
        
        if (_isJumping)
        {
            _animator.Play("JumpAnimation");
            return;
        }

        if (_isWalking)
        {
            _animator.Play("WalkAnimation");
        }
    }
}