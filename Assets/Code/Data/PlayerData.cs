using UnityEngine;

namespace Code
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Data/Settings/PlayerSettings")]
    public class PlayerData : ScriptableObject
    {
        public Material Material;
        public Mesh Mesh;
        [SerializeField, Range(0, 100)] private float _speed;
        public float Mass;
        public float AngularDrag;

        public float Speed => _speed;
    }
}