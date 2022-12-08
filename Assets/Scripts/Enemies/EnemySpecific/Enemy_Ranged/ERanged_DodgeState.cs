using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ERanged_DodgeState : DodgeState
{
    private Enemy_Ranged enemy;

    public ERanged_DodgeState(
        Entity etity,
        FiniteStateMachine stateMachine,
        string animBoolName,
        D_DodgeState stateData,
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

        if (isDodgeOver)
        {
            if (isPlayerInMaxAgroRange && !performCloseRangeAction)
            {
                stateMachine.ChangeState(enemy.attackState);
            }
            else if (!isPlayerInMaxAgroRange)
            {
                stateMachine.ChangeState(enemy.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
