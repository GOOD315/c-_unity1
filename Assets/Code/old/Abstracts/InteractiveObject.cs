using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.XR.WSA.Input;


namespace Code
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable
    {
        public bool IsInteractable { get; } = true;
        public abstract void Interaction(Collider col);

        private void OnTriggerEnter(Collider col)
        {
            if (!IsInteractable || !col.CompareTag("Player") && !col.CompareTag("PlayerBullet")) return;
            Interaction(col);
        }
    }
}