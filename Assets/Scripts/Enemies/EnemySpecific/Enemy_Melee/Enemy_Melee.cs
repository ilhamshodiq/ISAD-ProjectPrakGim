using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Melee : Entity
{
    public EMelee_IdleState idleState { get; private set; }
    public EMelee_MoveState moveState { get; private set; }
    public EMelee_PlayerDetectedState playerDetectedState { get; private set; }
    public EMelee_LookForPlayerState lookForPlayerState { get; private set; }
    public EMelee_DeadState deadState { get; private set; }
    public EMelee_AttackState attackState { get; private set; }

    [SerializeField]
    private D_IdleState idleStateData;

    [SerializeField]
    private D_MoveState moveStateData;

    [SerializeField]
    private D_PlayerDetected playerDetectedData;

    [SerializeField]
    private D_LookForPlayer lookForPlayerStateData;

    [SerializeField]
    private D_DeadState deadStateData;

    [SerializeField]
    private D_MeleeAttack attackStateData;

    [SerializeField]
    private Transform meleeAttackPosition;

    public override void Start()
    {
        base.Start();
        moveState = new EMelee_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new EMelee_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new EMelee_PlayerDetectedState(
            this,
            stateMachine,
            "playerDetected",
            playerDetectedData,
            this
        );
        lookForPlayerState = new EMelee_LookForPlayerState(
            this,
            stateMachine,
            "lookForPlayer",
            lookForPlayerStateData,
            this
        );
        deadState = new EMelee_DeadState(this, stateMachine, "dead", deadStateData, this);
        attackState = new EMelee_AttackState(
            this,
            stateMachine,
            "attack",
            meleeAttackPosition,
            attackStateData,
            this
        );

        stateMachine.Initialize(moveState);
    }

    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);

        if (isDead)
        {
            stateMachine.ChangeState(deadState);
        }
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(meleeAttackPosition.position, attackStateData.attackRadius);
    }
}
