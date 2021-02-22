using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public abstract class Spawner : MonoBehaviour, ISpawner
    {
        protected bool _isActive;

        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }

        public abstract void Spawn();

        public abstract void FindSpawnObjects();
        public abstract void FindSpawnPoints();
    }
}