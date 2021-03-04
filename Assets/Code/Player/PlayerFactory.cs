using UnityEngine;

namespace Code
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly PlayerData _PlayerData;

        public PlayerFactory(PlayerData playerData)
        {
            _PlayerData = playerData;
        }

        public Transform CreatePlayer()
        {
            return new GameObject("player").AddMesh(_PlayerData.Mesh).AddMeshRenderer(_PlayerData.Material)
                .AddSphereCollider().AddRigidBody(_PlayerData.Mass, _PlayerData.AngularDrag).transform;
        }
    }
}