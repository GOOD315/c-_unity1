using UnityEngine;

namespace Code
{
    public class TrapFactory : ITrapFactory
    {
        private readonly TrapData _data;

        public TrapFactory(TrapData data)
        {
            _data = data;
        }

        public TrapData Data
        {
            get { return _data; }
        }

        public GameObject CreateTrap(int index, Transform pos)
        {
            var trap = _data.GetTrap(index);
            return Object.Instantiate(trap, pos);
        }
    }
}