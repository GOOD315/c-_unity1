using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    [Serializable]
    public class CurrentActiveTrapsList : IEnumerable, IEnumerator
    {
        private int _index = -1;
        private List<GameObject> _trapsList;

        public CurrentActiveTrapsList(Dictionary<int, GameObject> trapsList)
        {
            foreach (var item in trapsList)
            {
                _trapsList.Add(item.Value);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool MoveNext()
        {
            if (_index == _trapsList.Count - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset()
        {
        }

        public object Current
        {
            get { return _trapsList[_index]; }
        }

        public override string ToString()
        {
            var str = "";
            foreach (var trap in _trapsList)
            {
                str += $"TrapType - {trap.GetComponent<Trap>() } \n";
            }

            return str;
        }
    }
}