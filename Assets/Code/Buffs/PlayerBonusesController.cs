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
        private List<TrapBuff> _activeBuffList;
        private TrapData _trapData;

        public List<TrapBuff> TrapBuffList => _activeBuffList;

        public PlayerBonusesController(PlayerBall player, TrapData trapData)
        {
            _player = player;
            _activeBuffList = new List<TrapBuff>();
            _trapData = trapData;
        }

        public void Initialization()
        {
        }

        public void Execute(float deltaTime)
        {
            for (var i = 0; i < _activeBuffList.Count; i++)
            {
                var trap = _activeBuffList[i];

                if (trap.IsActive == true) trap.Execute(deltaTime);
                else
                {
                    trap.DeBuff();
                    trap.Cleanup();
                    _activeBuffList.Remove(trap);
                }
            }
        }

        public void PlayerGotBonus(Trap trap)
        {
            trap.trapBuff.Buff(_player);
            _activeBuffList.Add(trap.trapBuff);

        /*    if (trap is HealingTrap)
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
                _activeBuffList.Add(slowBuff);
            }

            if (trap is HasteTrap)
            {
                var hasteBuff = new HasteBuff(_player);
                hasteBuff.Buff();
                _activeBuffList.Add(hasteBuff);
            }

            if (trap is DeathTrap)
            {
                _player.Health = 0;
            }*/
        }


        public void Cleanup()
        {
        }
    }
}