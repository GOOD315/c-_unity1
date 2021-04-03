using UnityEngine;

namespace Code.Buffs
{
    public class SlowBuff : TrapBuff
    {
        public SlowBuff()
        {
            _buffType = BuffType.SlowBuff;
            _timer = 100;
        }

        public override void Buff(PlayerBall player)
        {
            _player = player;
            _player.Speed -= 5;
        }

        public override void DeBuff()
        {
            _player.Speed += 5;
        }
    }
}