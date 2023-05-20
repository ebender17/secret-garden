namespace Player.States
{
    public class PlayerIdleState : PlayerStateBase
    {
        public PlayerIdleState(PlayerController player, PlayerStateMachine stateMachine, PlayerData playerData, string animName) : base(player, stateMachine, playerData, animName)
        {

        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();

            player.SetVelocityX(0.0f);
        }

        public override void Execute()
        {
            base.Execute();

            if (!isExitingState)
            {
                if (xInput != 0 || yInput != 0)
                {
                    stateMachine.ChangeState(player.MoveState);
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