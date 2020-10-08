using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoManaText : MonoBehaviour
{
    public IEnumerator SetActiveText()
    {
        transform.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        transform.gameObject.SetActive(false);
    }
}
