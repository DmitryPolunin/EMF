using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void SetMana(int mana)
    {
        _slider.value = mana;
    }
}
