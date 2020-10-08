using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] private Transform _shootEndPos;
    [SerializeField] private MoveCrosshair _moveCrosshair;

    void Update()
    {
        if (_moveCrosshair.isTriggered)
        {
            _shootEndPos.transform.position = _moveCrosshair.collisionPos + new Vector3(0,3.5f,0);
            
        }
        else
        {
            _shootEndPos.localPosition = new Vector3(0f, 1f, 9f);
        }
        transform.LookAt(_shootEndPos);    
    }
}
