using UnityEngine;

namespace Code.Buffs
{
    public class SlowBuff : TrapBuff
    {
        public SlowBuff(PlayerBall player) : base(player)
        {
            _time = 5;
        }

        public override void Buff()
        {
            _player.Speed -= 5;
        }

        public override void DeBuff()
        {
            _player.Speed += 5;
        }
    }
}