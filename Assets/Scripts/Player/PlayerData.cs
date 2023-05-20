using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "newPlayerData", menuName = "Player Data/Base Data")]
    public class PlayerData : ScriptableObject
    {
        [Header("Move State")]
        public float speed = 3.0f;
    }
}