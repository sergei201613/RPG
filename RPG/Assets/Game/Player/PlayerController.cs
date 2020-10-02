using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;
    
    private Camera _camera;
    private PlayerMotor _motor;
    private Interactable _focus;

    private void Awake()
    {
        _camera = Camera.main;
        _motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit, 100, movementMask))
            {
                _motor.MoveToPoint(hit.point);
                RemoveFocus();
            }
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit, 100))
            {
                var interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                    SetFocus(interactable);
            }
        }
    }

    private void SetFocus(Interactable newFocus)
    {
        _focus = newFocus;
        _motor.FollowTarget(newFocus);
    }

    private void RemoveFocus()
    {
        _focus = null;
        _motor.StopFollowingTarget();
    }
}
