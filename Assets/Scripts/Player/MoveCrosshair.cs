using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCrosshair : MonoBehaviour
{
    private Vector3 _collisionPos;
    public Vector3 collisionPos 
    {
        get { return _collisionPos; } 
    }
    public bool isTriggered;
    private void Start()
    {
        isTriggered = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "FireSummon")
        {
            _collisionPos = other.transform.position;
            isTriggered = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isTriggered = false;
    }
}
