using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEditor;
using UnityEngine;
using Object = System.Object;
using Random = UnityEngine.Random;

namespace Code
{
    sealed class TrapSpawner : Spawner
    {
        [SerializeField] private GameObject HealingTrap;
        [SerializeField] private GameObject DamageTrap;
        [SerializeField] private GameObject SlowTrap;
        [SerializeField] private GameObject HasteTrap;

        private Dictionary<Transform, bool> spawnPoints;
        private List<Transform> spawnPointsKeys;
        private Object[] trapsList;

        private void Awake()
        {
            activeSpawnObjectsCnt = 0;
            maxSpawnObjectsCnt = 10;

            FindSpawnPoints();
            FindSpawnObjects();
        }

        public override void CallSpawner(TrapSpawnController controller)
        {
            controller.currentTrapsCnt -= 1;
            print("ff");
        }

        public override void FindSpawnPoints()
        {
            spawnPoints = new Dictionary<Transform, bool>();
            spawnPointsKeys = new List<Transform>();

            GameObject[] spGameObjects = GameObject.FindGameObjectsWithTag("TrapSpawnPoint");
            foreach (var item in spGameObjects)
            {
                spawnPoints.Add(item.transform, false);
                spawnPointsKeys.Add(item.transform);
            }
        }

        public override void FindSpawnObjects()
        {
            trapsList = Resources.LoadAll("MyAssets/Traps", typeof(GameObject));
        }

        public override void SpawnTraps(TrapSpawnController spawnContr)
        {
            if (spawnPointsKeys.Count == 0 || trapsList.Length == 0) return;

            var cnt = Random.Range(0, spawnPointsKeys.Count - 1);
            if (spawnPoints[spawnPointsKeys[cnt]] == false)
            {
                spawnPoints[spawnPointsKeys[cnt]] = true;
                var mineType = Random.Range(0, trapsList.Length - 1);

                Spawn((GameObject) trapsList[mineType], spawnPointsKeys[cnt], spawnContr);
            }
        }

        private void Update()
        {
            // if (activeSpawnObjectsCnt < maxSpawnObjectsCnt) SpawnTraps();
        }
    }
}