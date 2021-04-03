using System;
using System.Collections;
using System.Collections.Generic;
using Code.Buffs;
using UnityEngine;

namespace Code
{
    [Serializable]
    public class CurrentActiveBuffsList : IEnumerable, IEnumerator
    {
        private int _index = -1;
        private List<TrapBuff> _currentActiveBuffsList;
        private BuffData _buffData;

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (_index == _currentActiveBuffsList.Count - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset() => _index = -1;
        public object Current => _currentActiveBuffsList[_index];
        public int Length => _currentActiveBuffsList.Count;

        public void AddBuff(string name, string timer)
        {
            int _timer;

            if (int.TryParse(timer, out _timer))
            {
                foreach (TrapBuff buff in _buffData)
                {
                    Debug.Log($"buffData - {buff}");
                    Debug.Log($"buff - {name}");
                    if (name == buff.ToString())
                    {
                    }
                }
            }
        }
    }
}