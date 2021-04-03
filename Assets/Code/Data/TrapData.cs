using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Code.Buffs;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

namespace Code
{
    [CreateAssetMenu(fileName = "TrapSettings", menuName = "Data/Settings/TrapSettings")]
    public sealed class TrapData : ScriptableObject, IEnumerable, IEnumerator
    {
        private int _index = -1;
        private TrapInfo _current;

        public int Index
        {
            get => _index;
            set => _index = value;
        }

        [Serializable]
        public struct TrapInfo
        {
            public GameObject trapObject;
        }

        [SerializeField] private List<TrapInfo> _trapInfos;

        public GameObject GetTrap(int index)
        {
            var trapInfo = _trapInfos[index];
            return trapInfo.trapObject;
        }

        public TrapInfo GetRandomTrap()
        {
            var rnd = Random.Range(0, _trapInfos.Count);
            return _trapInfos[rnd];
        }

        public bool MoveNext()
        {
            if (_index == _trapInfos.Count - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset() => _index = -1;
        public object Current => _trapInfos[_index];
        public int Length => _trapInfos.Count;

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}