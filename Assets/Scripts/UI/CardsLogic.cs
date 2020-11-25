using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsLogic : MonoBehaviour
{
    [SerializeField] private Image[] _Cards = new Image[3];
    [SerializeField] private Player _player;


    private void Update()
    {
        if (_player.mana >= 15) SetActive(_Cards[0]);
        else SetInactive(_Cards[0]);

        if (_player.mana >= 30) SetActive(_Cards[1]);
        else SetInactive(_Cards[1]);

        if (_player.mana >= 50) SetActive(_Cards[2]);
        else SetInactive(_Cards[2]);
    }

    public void SetActive(Image image)
    {
        image.color = Color.white;
        image.transform.localScale = Vector3.one;
    }

    public void SetInactive (Image image)
    {
        image.color = Color.gray;
        image.transform.localScale = new Vector3(1, 0.5f, 1);
    }
}
