using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBuffSphere : MonoBehaviour
{
    [SerializeField] private Player _player;
    private void OnTriggerEnter (Collider collider)
    {
        if(collider.gameObject.GetComponent<ReactiveTarget>() != null)
        {
            StartCoroutine(_player.BlueBuff());
            Destroy(gameObject);
        }
    }
}
