using Code.Buff;

namespace Code.Buffs
{
    public class DamageBuff : TrapBuff, IDamageBuff
    {
        public DamageBuff()
        {
            _buffType = BuffType.DamageBuff;
        }

        public override void Buff(PlayerBall player)
        {
            _player = player;
            _player.Health -= 50;
        }

        public override void DeBuff()
        {
        }
    }
}