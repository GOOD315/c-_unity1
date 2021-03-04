using System;
using System.Collections;
using System.Collections.Generic;
using Code;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using Object = System.Object;

namespace Code
{
    /*   public class GameController : MonoBehaviour
       {
           public Text _finishGameLabel;
           private DisplayEndGame _displayEndGame;
   
           [SerializeField] private bool _isActive;
           private GameObject player;
   
           private TrapSpawnController trapSpawnController;
   
           private void Awake()
           {
               trapSpawnController = new TrapSpawnController();
               player = GameObject.FindGameObjectWithTag("Player");
           }
   
           private void Start()
           {
               Check();
           }
   
           private void Check()
           {
               var listInteractableObjects = new ListInteractableObject();
               foreach (var item in listInteractableObjects)
               {
                   print(item);
               }
   
               _isActive = false;
           }
   
           private void Update()
           {
               if (_isActive) Check();
           }
   
           private void EndGame()
           {
           }
       }
       */
}