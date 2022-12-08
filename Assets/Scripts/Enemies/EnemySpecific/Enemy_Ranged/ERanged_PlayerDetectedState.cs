using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ERanged_PlayerDetectedState : PlayerDetectedState
{
    private Enemy_Ranged enemy;

    public ERanged_PlayerDetectedState(
        Entity etity,
        FiniteStateMachine stateMachine,
        string animBoolName,
        D_PlayerDetected stateData,
        Enemy_Ranged enemy
    ) : base(etity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        // if (performLongRangeAction)
        // {
        //     stateMachine.ChangeState(enemy.chargeState);
        // }
        if (!isPlayerInMaxAgroRange)
        {
            stateMachine.ChangeState(enemy.lookForPlayerState);
        }
        else if (!isDetectingLedge)
        {
            entity.Flip();
            stateMachine.ChangeState(enemy.moveState);
        }
    }
}
