using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace Input
{
    public enum GameSchemas 
    { 
        Ground = 0,
        Water,
        Menus,
        Dialogue,
        None
    }

    /// <summary>
    /// Made a scriptable object so it can be acessed from anywhere in project. 
    /// </summary>

    [CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
    public class InputReader : ScriptableObject, PlayerInput.IGroundActions
    {
        private PlayerInput playerInput;
        private GameSchemas currentSchema;


        //Assign deletgate{} to events to initialize them with an empty delegate so we can skip the null check when we use them 
        //Gameplay
        public event UnityAction<Vector2> moveEvent = delegate { };
        public event UnityAction interactEvent = delegate { };


        public GameSchemas CurrentSchema { get => currentSchema; set => currentSchema = value; }


        private void OnEnable()
        {
            if (playerInput == null)
            {
                playerInput = new PlayerInput();
                playerInput.Ground.SetCallbacks(this);
            }

            EnableGroundInput();
        }

        private void OnDisable()
        {
            DisableAllInput();
        }


        public void OnMovement(InputAction.CallbackContext context)
        {
            moveEvent.Invoke(context.ReadValue<Vector2>());
        }

        public void EnableGroundInput()
        {
            playerInput.Ground.Enable();

            currentSchema = GameSchemas.Ground;
        }

        public void DisableAllInput()
        {
            playerInput.Ground.Disable();

            currentSchema = GameSchemas.None;
        }
    }
}