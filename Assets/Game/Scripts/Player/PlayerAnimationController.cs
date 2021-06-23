using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : CharacterAnimationController
{
    IDamageable damageable;

    protected override void Awake()
    {
        base.Awake();

        damageable = GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.DeathEvent += OnDeath;
        }
    }

    protected override void Update()
    {
        base.Update();
        animator.SetBool(CharacterMovementAnimationKeys.IsCrouching, playerMovement.IsCrouching);
        animator.SetFloat(CharacterMovementAnimationKeys.VerticalSpeed, playerMovement.CurrentVelocity.y / playerMovement.JumpSpeed);
        animator.SetBool(CharacterMovementAnimationKeys.IsGrounded, playerMovement.IsGrounded);
    }

    private void OnDestroy()
    {
        if (damageable != null)
        {
            damageable.DeathEvent -= OnDeath;
        }
    }

    private void OnDeath()
    {
        animator.SetTrigger(CharacterMovementAnimationKeys.Dead);
    }
}