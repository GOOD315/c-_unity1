using UnityEngine;
using Object = System.Object;

namespace Code.Shooting
{
    internal class PlayerShoot : Shoot
    {
        public PlayerBall player;
        public PCMouseInput mouseInput;

        internal PlayerShoot(PlayerBall player)
        {
            this.player = player;
            mouseInput = new PCMouseInput();
        }

        public void DefaultShoot(GameObject bullet)
        {
            var myPos = player.transform.position;
            var aimFromMouse = getAimFromMouse();
            var aimPos = new Vector3(aimFromMouse.x, myPos.y, aimFromMouse.z);

            base.DefaultShoot(bullet, myPos, aimPos);
        }

        private Vector3 getAimFromMouse()
        {
            var ray = Camera.main.ScreenPointToRay(mouseInput.GetMouse());
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            return hit.point;
        }
    }
}