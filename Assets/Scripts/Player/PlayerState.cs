using UnityEngine;

namespace Player
{
    public class PlayerState
    {
        protected PlayerController player;
        protected PlayerStateMachine stateMachine;
        protected PlayerData playerData;
        protected float startTime;
        protected bool isAnimationFinished;
        protected bool isExitingState;


        private string animName;


        public string AnimName { get => animName; }


        public PlayerState(PlayerController player, PlayerStateMachine stateMachine, PlayerData playerData, string animName)
        {
            this.player = player;
            this.stateMachine = stateMachine;
            this.playerData = playerData;
            this.animName = animName;
        }

        public virtual void Enter()
        {
            player.Animator.SetBool(animName, true);
            startTime = Time.time;
            isAnimationFinished = false;
            isExitingState = false;
        }

        public virtual void Exit()
        {
            player.Animator.SetBool(animName, false);
            isExitingState = true;
        }

        public virtual void Execute()
        {

        }

        public virtual void ExecutePhysics()
        {
            DoChecks();
        }

        public virtual void DoChecks() { }

        public virtual void AnimationFinish() => isAnimationFinished = true;
    }
}