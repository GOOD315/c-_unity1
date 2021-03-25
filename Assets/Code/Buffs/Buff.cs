using System;
using UnityEngine;

namespace Code.Buffs
{
    public abstract class TrapBuff : IExecute, ICleanup
    {
        protected PlayerBall _player;
        protected bool _isActive;
        protected float _timer;
        protected float _time;

        public bool IsActive => _isActive;

        public TrapBuff(PlayerBall player)
        {
            _player = player;
            _isActive = true;
        }

        public void Execute(float deltaTime)
        {
            if (_timer >= _time)
            {
                _isActive = false;
            }

            _timer += deltaTime;
        }

        public void Cleanup()
        {
        }

        public abstract void Buff();
        public abstract void DeBuff();
    }
}