using UnityEngine;


namespace Player 
{
    public class PlayerStateMachine 
    {
        private PlayerState currentState;


        public PlayerState CurrentState { get => currentState; }


        public void Initialize(PlayerState startingState)
        {
            Debug.Log("Starting state " + startingState.AnimName);
            currentState = startingState;
            currentState.Enter();
        }

        public void ChangeState(PlayerState newState)
        {
            Debug.Log("Changing state to " + newState.AnimName);
            currentState.Exit();
            currentState = newState;
            newState.Enter();
        }
    }
}