using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.States
{
    public class PlayerMoveState : PlayerStateBase
    {
        private Vector2 velocity;


        public PlayerMoveState(PlayerController player, PlayerStateMachine stateMachine, PlayerData playerData, string animName) : base(player, stateMachine, playerData, animName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Execute()
        {
            base.Execute();

            player.SetVelocityX(xInput * playerData.speed);
            player.SetVelocityY(yInput * playerData.speed);

            player.Animator.SetFloat("Horizontal", xInput);
            player.Animator.SetFloat("Vertical", yInput);

            if (xInput == 1 || xInput == -1 || yInput == 1 || yInput == -1)
            {
                player.Animator.SetFloat("LastHorizontal", xInput);
                player.Animator.SetFloat("LastVertical", yInput);
            }

            if (!isExitingState)
            {
                if (xInput == 0 && yInput == 0)
                {
                    stateMachine.ChangeState(player.IdleState);
                }
            }
        }

        public override void ExecutePhysics()
        {
            base.ExecutePhysics();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}