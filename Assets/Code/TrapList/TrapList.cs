using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class TrapList : IInitialization
    {
        private TrapData _trapData;


        public TrapList(TrapData trapData)
        {
            _trapData = trapData;
        }

        public GameObject GetRandomTrap()
        {
            var trap = _trapData.GetTrap(Random.Range(0, _trapData.Length));
            return trap;
        }

        public GameObject GetTrap(int index)
        {
            return _trapData.GetTrap(index);
        }

        public void Initialization()
        {
        }
    }
}