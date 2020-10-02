using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float smooth = 5f;
    
    private Transform _player;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerController>().transform;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Slerp(transform.position, _player.position, Time.deltaTime * smooth);
    }
}
