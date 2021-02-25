using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public abstract class Spawner : MonoBehaviour, ISpawner
    {
        protected bool _isActive;

        protected int activeSpawnObjectsCnt;
        protected int maxSpawnObjectsCnt;

        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }

        public void Spawn(GameObject obj, Transform place, TrapSpawnController trapSpawnController)
        {
            var temp = Instantiate(obj, place);
            activeSpawnObjectsCnt++;

            try
            {
                var trapScr = obj.GetComponent<Trap>();
                trapScr.controller = trapSpawnController;
                trapScr.callController += CallSpawner;
            }
            catch (Exception exc)
            {
                Debug.Log(exc.Message);
            }
        }

        public abstract void SpawnTraps(TrapSpawnController spawnContr);
        public abstract void CallSpawner(TrapSpawnController controller);
        public abstract void FindSpawnObjects();
        public abstract void FindSpawnPoints();
    }
}