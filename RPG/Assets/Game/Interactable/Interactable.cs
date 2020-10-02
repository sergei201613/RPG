using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;

    public virtual void Interact(GameObject interactedCharacter)
    {
        Debug.Log(interactedCharacter.name + " interacting with " + name);
    }
    
    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
