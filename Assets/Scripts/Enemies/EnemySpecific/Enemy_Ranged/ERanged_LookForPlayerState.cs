using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ERanged_LookForPlayerState : LookForPlayerState
{
    private Enemy_Ranged enemy;

    public ERanged_LookForPlayerState(
        Entity etity,
        FiniteStateMachine stateMachine,
        string animBoolName,
        D_LookForPlayer stateData,
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

        if (isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
        else if (isAllTurnsTimeDone)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }
}
