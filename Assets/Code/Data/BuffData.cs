using System;
using System.Collections;
using System.Collections.Generic;
using Code.Buffs;
using UnityEngine;

namespace Code
{
    public sealed class BuffData : IEnumerable, IEnumerator
    {
        private int _index = -1;
        private List<TrapBuff> _trapBuffs;

        public BuffData()
        {
            _trapBuffs = new List<TrapBuff>();
            _trapBuffs.Add(new DamageBuff());
            _trapBuffs.Add(new DeathBuff());
            _trapBuffs.Add(new HasteBuff());
            _trapBuffs.Add(new SlowBuff());
            _trapBuffs.Add(new HealingBuff());
        }

        private TrapBuff this[int _index]
        {
            get => _trapBuffs[_index];
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (_index == _trapBuffs.Count - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset() => _index = -1;
        public object Current => _trapBuffs[_index];
        public int Length => _trapBuffs.Count;
    }
}