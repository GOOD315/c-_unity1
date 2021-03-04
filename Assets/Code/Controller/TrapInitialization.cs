using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Code
{
    public sealed class TrapInitialization : IInitialization
    {
        private readonly TrapFactory _trapFactory;
        private List<Trap> _traps;

        private Dictionary<Transform, bool> spawnPoints;
        private List<Transform> spawnPointsKeys;

        private readonly int _getInstanceID;
        private TrapController _trapController;

        public TrapInitialization(TrapFactory trapFactory, int getInstanceID, TrapController trapController)
        {
            _trapFactory = trapFactory;
            _getInstanceID = getInstanceID;
            _trapController = trapController;

            GameObject[] spGameObjects = GameObject.FindGameObjectsWithTag("TrapSpawnPoint");
            foreach (var item in spGameObjects)
            {
                spawnPoints.Add(item.transform, false);
                spawnPointsKeys.Add(item.transform);
            }
        }

        public void Initialization()
        {
        }

        // Не понял как лучше изменять счетчик текущих заспавненых мин, поэтому просто передал значение как currentSpawnedTraps
        // наверное есть способ получше??
        public void SpawnTraps(int numberTrapsShouldSpawn)
        {
            if (spawnPointsKeys.Count == 0 || _trapFactory.Data.Length == 0) return;

            int _numberTrapsShouldSpawn = numberTrapsShouldSpawn;
            while (_numberTrapsShouldSpawn > 0)
            {
                if (InitializeTrap())
                {
                    _trapController?.ChangeNumOfActiveTraps(1);
                    _numberTrapsShouldSpawn -= 1;
                }
            }
        }

        public bool InitializeTrap()
        {
            var cnt = Random.Range(0, spawnPointsKeys.Count - 1);
            if (spawnPoints[spawnPointsKeys[cnt]] == false)
            {
                var mineType = Random.Range(0, _trapFactory.Data.Length - 1);

                var trap = _trapFactory.CreateTrap(mineType, spawnPointsKeys[cnt]);
                var trapScr = trap.GetComponent<Trap>();
                trapScr.trapController = _trapController;
                trapScr.CallControllerOnTrigger += CallTrapController;

                spawnPoints[spawnPointsKeys[cnt]] = true;

                return true;
            }

            return false;
        }

        private void CallTrapController(int value, TrapController trapController)
        {
            if (value == _getInstanceID)
            {
                Debug.Log("СРАБОТАЛА");
                trapController.ChangeNumOfActiveTraps(-1);
            }
        }
    }
}