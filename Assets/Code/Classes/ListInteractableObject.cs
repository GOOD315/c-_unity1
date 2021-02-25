using System.Collections;
using UnityEngine;

namespace Code
{
    public class ListInteractableObject : IEnumerator, IEnumerable
    {
        private InteractiveObject[] _interactiveObjects;
        private int _index = -1;

        public ListInteractableObject()
        {
            _interactiveObjects = Object.FindObjectsOfType<DeathTrap>();
        }

        public bool MoveNext()
        {
            if (_index == _interactiveObjects.Length - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset() => _index = -1;

        public object Current => _interactiveObjects[_index];

        public IEnumerator getEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return getEnumerator();
        }
        
        
    }
}