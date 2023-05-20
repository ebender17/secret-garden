using UnityEngine;
using Input;
using Player.States;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        // TODO - do we want to use RigidBody?
        [SerializeField]
        private PlayerData playerData;
        [SerializeField]
        private InputReader inputReader;
        [SerializeField]
        private Rigidbody2D rigidBody;
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private SpriteRenderer spriteRenderer;


        private PlayerStateMachine stateMachine;
        private PlayerState currentPlayerState;
        private PlayerIdleState idleState;
        private PlayerMoveState moveState;
        private Vector2 rawMovement;
        private int normInputX;
        private int normInputY;
        private Vector2 currentVelocity;
        private Vector2 tempValue;


        public PlayerStateMachine StateMachine { get => stateMachine; }
        public PlayerIdleState IdleState { get => idleState; }
        public PlayerMoveState MoveState { get => moveState;  }
        public InputReader InputReader { get => inputReader; }
        public Rigidbody2D RigidBody { get => rigidBody; }
        public Animator Animator { get => animator; }
        public SpriteRenderer Renderer { get => spriteRenderer; }
        public int NormInputX { get => normInputX; set => normInputX = value; }
        public int NormInputY { get => normInputY; set => normInputY = value; }
        public Vector2 CurrentVelocity { get => currentVelocity; set => currentVelocity = value; }


        #region Unity Functions

        private void Awake()
        {
            stateMachine = new PlayerStateMachine();

            idleState = new PlayerIdleState(this, stateMachine, playerData, "Idle");
            moveState = new PlayerMoveState(this, stateMachine, playerData, "Move");
        }

        private void OnEnable()
        {
            inputReader.moveEvent += OnMovement;
        }

        private void OnDisable()
        {
            inputReader.moveEvent -= OnMovement;
        }

        private void Start()
        {
            stateMachine.Initialize(idleState);
        }

        private void Update()
        {
            currentVelocity = rigidBody.velocity;

            stateMachine.CurrentState.Execute();
        }

        private void FixedUpdate()
        {
            stateMachine.CurrentState.ExecutePhysics();
        }
        #endregion


        #region Movement
        private void OnMovement(Vector2 inputMovement)
        {
            Debug.Log("inside on movement in player controller");
            rawMovement = inputMovement;

            if(Mathf.Abs(rawMovement.x) > 0.5f)
            {
                normInputX = (int)(rawMovement * Vector2.right).normalized.x;
            }
            else
            {
                normInputX = 0;
            }

            if (Mathf.Abs(rawMovement.y) > 0.5f)
            {
                normInputY = (int)(rawMovement * Vector2.up).normalized.y;
            }
            else
            {
                normInputY = 0;
            }
        }

        public void SetVelocity(Vector2 value)
        {
            currentVelocity = value;
        }

        public void SetVelocityX(float value)
        {
            tempValue.Set(value, currentVelocity.y);
            rigidBody.velocity = tempValue;
            currentVelocity = tempValue;
            Debug.Log("Current velocity: " + currentVelocity.ToString());
        }

        public void SetVelocityY(float value)
        {
            tempValue.Set(currentVelocity.x, value);
            rigidBody.velocity = tempValue;
            currentVelocity = tempValue;
        }
        #endregion


        #region Animation
        void AnimationFinishedCallback(AnimationEvent evt)
        {
            if(evt.animatorClipInfo.weight > 0.5)
            {
                stateMachine.CurrentState.AnimationFinish();
            }
        }
        #endregion
    }
}