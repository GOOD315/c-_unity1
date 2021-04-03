namespace Code.Buffs
{
    public class DeathBuff : TrapBuff
    {
        public DeathBuff()
        {
            _buffType = BuffType.DeathBuff;
        }

        public override void Buff(PlayerBall player)
        {
            _player = player;
            _player.Die();
        }

        public override void DeBuff()
        {
        }
    }
}