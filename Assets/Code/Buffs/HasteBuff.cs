namespace Code.Buffs
{
    public class HasteBuff : TrapBuff
    {
        public HasteBuff(PlayerBall player) : base(player)
        {
            _time = 5;
        }

        public override void Buff()
        {
            _player.Speed += 50;
        }

        public override void DeBuff()
        {
            _player.Speed -= 50;
        }
    }
}