using System;
using UnityEngine;

namespace Code.Buffs
{
    public abstract class TrapBuff : IExecute, ICleanup
    {
        protected PlayerBall _player;
        protected bool _isActive;
        protected float _timer;
        protected BuffType _buffType;

        public BuffType BuffType => _buffType;

        public float Timer
        {
            get { return _timer; }

            set { _timer = value; }
        }

        public bool IsActive => _isActive;

        public TrapBuff()
        {
            _isActive = true;
        }


        public void Execute(float deltaTime)
        {
            if (_timer <= 0)
            {
                _isActive = false;
            }

            _timer -= deltaTime;
        }

        public void Cleanup()
        {
        }

        public abstract void Buff(PlayerBall player);
        public abstract void DeBuff();
    }
}