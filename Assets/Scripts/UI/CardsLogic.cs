using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsLogic : MonoBehaviour
{
    [SerializeField] private Image[] Cards = new Image[3];
    [SerializeField] private Player player;


    private void Update()
    {
        if (player.mana >= 15) SetActive(Cards[0]);
        else SetInactive(Cards[0]);

        if (player.mana >= 30) SetActive(Cards[1]);
        else SetInactive(Cards[1]);

        if (player.mana >= 50) SetActive(Cards[2]);
        else SetInactive(Cards[2]);
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
