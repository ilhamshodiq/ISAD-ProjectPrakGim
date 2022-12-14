using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ranged : Entity
{
    public ERanged_IdleState idleState { get; private set; }
    public ERanged_MoveState moveState { get; private set; }
    public ERanged_PlayerDetectedState playerDetectedState { get; private set; }
    public ERanged_LookForPlayerState lookForPlayerState { get; private set; }
    public ERanged_DeadState deadState { get; private set; }
    public ERanged_AttackState attackState { get; private set; }
    public ERanged_DodgeState dodgeState { get; private set; }

    [SerializeField]
    public D_IdleState idleStateData;

    [SerializeField]
    public D_MoveState moveStateData;

    [SerializeField]
    public D_PlayerDetected playerDetectedData;

    [SerializeField]
    public D_LookForPlayer lookForPlayerStateData;

    [SerializeField]
    public D_DeadState deadStateData;

    [SerializeField]
    public D_RangedAttackState attackStateData;

    [SerializeField]
    public D_DodgeState dodgeStateData;



    [SerializeField]
    private Transform rangedAttackPosition;

    public override void Start()
    {
        base.Start();
        moveState = new ERanged_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new ERanged_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new ERanged_PlayerDetectedState(
            this,
            stateMachine,
            "playerDetected",
            playerDetectedData,
            this
        );
        lookForPlayerState = new ERanged_LookForPlayerState(
            this,
            stateMachine,
            "lookForPlayer",
            lookForPlayerStateData,
            this
        );
        deadState = new ERanged_DeadState(this, stateMachine, "dead", deadStateData, this);
        attackState = new ERanged_AttackState(
            this,
            stateMachine,
            "attack",
            rangedAttackPosition,
            attackStateData,
            this
        );
        dodgeState = new ERanged_DodgeState(this, stateMachine, "dodge", dodgeStateData, this);

        stateMachine.Initialize(moveState);
    }

    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);

        if (isDead)
        {
            stateMachine.ChangeState(deadState);
        }
        else if (CheckPlayerInMinAgroRange())
        {
            stateMachine.ChangeState(attackState);
        }
        else if (!CheckPlayerInMinAgroRange())
        {
            lookForPlayerState.SetTurnImmediately(true);
            stateMachine.ChangeState(lookForPlayerState);
        }
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }
}
