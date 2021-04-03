namespace Code.Buffs
{
    public class HealingBuff : TrapBuff
    {
        public HealingBuff()
        {
            _buffType = BuffType.HealingBuff;
        }

        public override void Buff(PlayerBall player)
        {
            _player = player;
            _player.Health += 50;
        }

        public override void DeBuff()
        {
        }
    }
}