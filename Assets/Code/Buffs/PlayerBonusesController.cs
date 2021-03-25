using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Code.Buffs;
using UnityEngine;

namespace Code
{
    public class PlayerBonusesController : IInitialization, IExecute, ICleanup
    {
        private PlayerBall _player;
        private List<TrapBuff> _trapBuffList;

        public PlayerBonusesController(PlayerBall player)
        {
            _player = player;
            _trapBuffList = new List<TrapBuff>();
        }

        public void Initialization()
        {
        }

        public void Execute(float deltaTime)
        {
            for (var i = 0; i < _trapBuffList.Count; i++)
            {
                var trap = _trapBuffList[i];

                if (trap.IsActive == true) trap.Execute(deltaTime);
                else
                {
                    trap.DeBuff();
                    trap.Cleanup();
                    _trapBuffList.Remove(trap);
                }
            }
        }

        public void PlayerGotBonus(Trap trap)
        {
            if (trap is HealingTrap)
            {
                _player.Health += 50;
            }

            if (trap is DamageTrap)
            {
                _player.Health -= 50;
            }

            if (trap is SlowTrap)
            {
                var slowBuff = new SlowBuff(_player);
                slowBuff.Buff();
                _trapBuffList.Add(slowBuff);
            }

            if (trap is HasteTrap)
            {
                var hasteBuff = new HasteBuff(_player);
                hasteBuff.Buff();
                _trapBuffList.Add(hasteBuff);
            }

            if (trap is DeathTrap)
            {
                _player.Health = 0;
            }
        }

        public void Cleanup()
        {
        }
    }
}