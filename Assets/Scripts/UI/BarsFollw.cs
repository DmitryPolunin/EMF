using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarsFollw : MonoBehaviour
{
    [SerializeField] private GameObject _fireMage;
    private float _offset = 4f;

    private void Update()
    {
        transform.position = new Vector3(_fireMage.transform.position.x, 10f, _fireMage.transform.position.z + _offset);
    }
}
