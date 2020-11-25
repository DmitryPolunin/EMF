using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public void ReactToHit(float damage)
    {
        Debug.Log("Popal na " + damage);
    }
}
