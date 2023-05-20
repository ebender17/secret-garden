namespace Player.States
{
    public class PlayerStateBase : PlayerState
    {
        protected float xInput;
        protected float yInput;


        public PlayerStateBase(PlayerController player, PlayerStateMachine stateMachine, PlayerData playerData, string animName) : base(player, stateMachine, playerData, animName)
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

            xInput = player.NormInputX;
            yInput = player.NormInputY;
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