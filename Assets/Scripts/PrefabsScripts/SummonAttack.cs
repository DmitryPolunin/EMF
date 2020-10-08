using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class SummonAttack : MonoBehaviour
{
    private float _damage = 10f;
    private bool isAttacked = false;
    private ReactiveTarget _reactiveTarget;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player2" && isAttacked == false)
        {
            _reactiveTarget = collider.gameObject.GetComponent<ReactiveTarget>();
            isAttacked = true;
            StartCoroutine(AttackDelay());
        }
    }
    private IEnumerator AttackDelay()
    {
        _reactiveTarget.ReactToHit(_damage);
        yield return new WaitForSeconds(1);
        isAttacked = false;
    }
}
