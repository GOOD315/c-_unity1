using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEditor;
using UnityEngine;
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
        private List<GameObject> trapsList;

        private int ActiveTraps = 0;
        private int maxActiveTraps = 10;

        private void Awake()
        {
            FindSpawnPoints();
            FindSpawnObjects();

            for (int i = 0; i < spawnPoints.Count; i++)
            {
            }
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

        // хочу сделать отдельное хранилище мин, и из него уже считывать, что бы можно было спокойно туда их добавлять и убирать, но не знаю как
        // сейчас пока просто костыль
        public override void FindSpawnObjects()
        {
            trapsList = new List<GameObject>();

            trapsList.Add(HealingTrap);
            trapsList.Add(DamageTrap);
            trapsList.Add(HasteTrap);
            trapsList.Add(SlowTrap);
        }

        public override void Spawn()
        {
            var cnt = Random.Range(0, spawnPointsKeys.Count - 1);
            if (spawnPoints[spawnPointsKeys[cnt]] == false)
            {
                spawnPoints[spawnPointsKeys[cnt]] = true;
                var mineType = Random.Range(0, trapsList.Count - 1);
                print($"{spawnPointsKeys[cnt].position.x} - {spawnPointsKeys[cnt].position.y} - {spawnPointsKeys[cnt].position.z}");
                GameObject temp = Instantiate(trapsList[mineType], spawnPointsKeys[cnt]);
            }

            ActiveTraps++;
        }


        private void Update()
        {
            if (ActiveTraps < maxActiveTraps) Spawn();
        }
    }
}