using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private Movement _victim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player1")
        {
            _victim = other.GetComponent<Movement>();
            if (_victim != null)
            {
                StartCoroutine(Trapped());
                Destroy(this.gameObject, 2.1f);
            }
        }
    }

    public IEnumerator Trapped()
    {
        Debug.Log("POIMALI TEBYA SOBAKA");
        _victim.isTrapped = true;
        yield return new WaitForSeconds(2f);
        _victim.isTrapped = false;
    }
}
