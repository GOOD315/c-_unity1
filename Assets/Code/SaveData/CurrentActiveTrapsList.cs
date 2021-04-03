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
        private TrapData _trapData;

        public CurrentActiveTrapsList()
        {
            _trapsList = new List<GameObject>();
            _trapData = Reference.TrapData;
        }

        public CurrentActiveTrapsList(Dictionary<int, GameObject> trapsList)
        {
            _trapsList = new List<GameObject>();
            _trapData = Reference.TrapData;
            foreach (var item in trapsList)
            {
                _trapsList.Add(item.Value);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
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

        public void Reset() => _index = -1;
        public object Current => _trapsList[_index];
        public int Length => _trapsList.Count;

        public override string ToString()
        {
            var str = "";
            foreach (var trap in _trapsList)
            {
                str +=
                    $"TrapType - {trap.name} TrapPosition - ({trap.transform.position.x},{trap.transform.position.y},{trap.transform.position.z}) \n";
            }

            return str;
        }

        public void AddTrap(string trapType, float x, float y, float z)
        {
            foreach (TrapData.TrapInfo trapInfo in _trapData)
            {
                if (trapInfo.trapObject.name == trapType)
                {
                    var trap = trapInfo.trapObject;
                    trap.transform.position = new Vector3(x, y, z);
                    _trapsList.Add(trap);
                }
            }
        }
    }
}