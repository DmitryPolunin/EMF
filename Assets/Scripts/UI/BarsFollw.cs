using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarsFollw : MonoBehaviour
{
    [SerializeField] private GameObject fireMage;
    private float offset = 4f;

    private void Update()
    {
        transform.position = new Vector3(fireMage.transform.position.x, 10f, fireMage.transform.position.z + offset);
    }
}
