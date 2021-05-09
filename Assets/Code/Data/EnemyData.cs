using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    [CreateAssetMenu(fileName = "EnemySettings", menuName = "Data/Settings/EnemySettings")]
    public sealed class EnemyData : ScriptableObject, IEnumerable, IEnumerator
    {
        private int _index = -1;

        public int Index
        {
            get => _index;
            set => _index = value;
        }

        [Serializable]
        public struct EnemyInfo
        {
            public GameObject enemyPrefab;
        }

        [SerializeField] private List<EnemyInfo> enemyList;

        public GameObject GetEnemy(int index)
        {
            if (index > enemyList.Count) return enemyList[0].enemyPrefab;
            return enemyList[index].enemyPrefab;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (_index == enemyList.Count - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset() => _index = -1;
        public object Current => enemyList[_index];
        public int Length => enemyList.Count;
    }
}