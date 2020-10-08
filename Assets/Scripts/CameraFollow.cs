using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Vector3 _offset = new Vector3(0,45f,-5f);
    private Vector3 _targetPosition;
    void LateUpdate()
    {
        _targetPosition = _player.position + _offset;
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, 0.045f);
    }
}
