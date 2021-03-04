using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Object = UnityEngine.Object;

namespace Code
{
    /*  public sealed class TrapSpawnController
      {
          [SerializeField] private bool _isActive;
          private Spawner[] TrapSpawnersList;
  
          public int currentTrapsCnt;
          private int maxTrapsCnt;
  
          public TrapSpawnController()
          {
              FindSpawners();
          }
  
          private void Start()
          {
          }
  
  
          private void FindSpawners()
          {
              TrapSpawnersList = Object.FindObjectsOfType<Spawner>();
              foreach (var item in TrapSpawnersList)
              {
                  Debug.Log(item.name);
              }
          }
  
          private void Update()
          {
              if (_isActive)
              {
                  foreach (var spawner in TrapSpawnersList)
                  {
                      spawner.SpawnTraps(this);
                  }
              }
          }
      }
      */
}