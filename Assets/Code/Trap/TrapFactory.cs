using UnityEngine;

namespace Code
{
    public class TrapFactory : ITrapFactory
    {
        private readonly TrapData _data;
        private ITrapFactory m_TrapFactoryImplementation;

        public TrapFactory(TrapData data)
        {
            _data = data;
        }

        public TrapData Data
        {
            get { return _data; }
        }

        public GameObject CreateTrap(GameObject trap, Transform pos)
        {
            return Object.Instantiate(trap, pos.position, Quaternion.identity);
        }
    }
}