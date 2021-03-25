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

        public PlayerBall CreatePlayer()
        {
            var player = Object.Instantiate(_PlayerData.playerScript, _PlayerData.PlayerSpawnPoint.transform.position,
                Quaternion.identity);
            /* return new GameObject("player")
                 .AddMesh(_PlayerData.Mesh)
                 .AddMeshRenderer(_PlayerData.Material)
                 .AddSphereCollider()
                 .AddRigidBody(_PlayerData.Mass, _PlayerData.AngularDrag)
                 .SetTransform(_PlayerData.PlayerSpawnPoint)
                 .transform;
                 */
            player.name = "Player";
            player.tag = "Player";
            return player;
        }
    }
}