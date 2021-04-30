using UnityEngine;

namespace Code.Buffs
{
    public class JumpBuff : TrapBuff
    {
        public JumpBuff()
        {
            _buffType = BuffType.JumpBuff;
            _timer = 0;
        }

        public override void Buff(PlayerBall player)
        {
            _player = player;
            _player.GetComponent<Rigidbody>().AddForce(new Vector3(0, 15, 0), ForceMode.Impulse);
        }

        public override void DeBuff()
        {
        }
    }
}