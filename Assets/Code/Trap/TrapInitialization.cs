using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Code
{
    public sealed class TrapInitialization : IInitialization
    {
        private readonly TrapFactory _trapFactory;
        private TrapData _trapData;

        private Dictionary<Transform, bool> spawnPoints = new Dictionary<Transform, bool>();
        private List<Transform> spawnPointsKeys = new List<Transform>();


        private readonly int _getInstanceID;
        private TrapController _trapController;
        private PlayerBonusesController _playerBonusesController;

        public TrapInitialization(TrapFactory trapFactory, int getInstanceID, TrapController trapController,
            PlayerBonusesController playerBonusesController, TrapData trapData)
        {
            _trapFactory = trapFactory;
            _getInstanceID = getInstanceID;
            _trapController = trapController;
            _trapData = trapData;
            _playerBonusesController = playerBonusesController;

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

        public void SpawnTraps(int numberTrapsShouldSpawn)
        {
            if (spawnPointsKeys.Count == 0 || _trapFactory.Data.Length == 0) return;

            int _numberTrapsShouldSpawn = numberTrapsShouldSpawn;
            while (_numberTrapsShouldSpawn > 0)
            {
                if (InitializeTrap())
                {
                    _numberTrapsShouldSpawn -= 1;
                }
                else
                {
                    Debug.Log("InitializeTrap Problem");
                }
            }
        }

        public bool InitializeTrap()
        {
            var cnt = Random.Range(0, spawnPointsKeys.Count - 1);
            if (spawnPoints[spawnPointsKeys[cnt]] == false)
            {
                var trapInfo = _trapData.GetRandomTrap();
                var trap = _trapFactory.CreateTrap(trapInfo.trapObject, spawnPointsKeys[cnt]);

                _trapController.AddActiveTrap(trap);

                var trapScr = trap.GetComponent<Trap>();
                trapScr.CallTrapControllerOnTrigger += CallTrapController;
                trapScr.CallPlayerBonusesControllerOnTrigger += CallPlayerBonusesController;

                spawnPoints[spawnPointsKeys[cnt]] = true;

                return true;
            }

            return false;
        }

        public bool InitializeTrap(int f)
        {
            return true;
        }

        private void CallTrapController(int playerInstanceID, int trapInstanceID)
        {
            if (playerInstanceID == _getInstanceID)
            {
                _trapController.RemoveActiveTrap(trapInstanceID);
            }
        }

        private void CallPlayerBonusesController(int playerInstanceID, int trapInstanceID, Trap trap)
        {
            if (playerInstanceID == _getInstanceID)
            {
                _playerBonusesController.PlayerGotBonus(trap);
            }
        }

        private void ClearTraps()
        {
        }

        private void LoadTraps()
        {
        }
    }
}