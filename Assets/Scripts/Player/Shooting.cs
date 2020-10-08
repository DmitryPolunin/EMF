using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Player player = null;
    [SerializeField] private NoManaText noMana = null;

    [SerializeField] private GameObject fireballPrefab = null;
    [SerializeField] private GameObject _trapPrefab = null;
    [SerializeField] private GameObject _summonPrefab = null;
    [SerializeField] private Transform _shootDir = null;
    [SerializeField] private Transform _shootEndPos = null;
    
    private GameObject _shootedAmmo;

    private void Start()
    {
        _shootEndPos.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            _shootEndPos.gameObject.SetActive(true);
        }
        
        //Shoot Fireball
        if (Input.GetKeyUp(KeyCode.J))
        {
            _shootEndPos.gameObject.SetActive(false);
            if (player.mana >= 15)
            {
                _shootedAmmo = Instantiate(fireballPrefab, _shootDir.position, _shootDir.rotation) as GameObject;
                player.ShootedFireball();
            }
            else
            {
                StartCoroutine(noMana.SetActiveText());
            }
        }
        //Place trap
        if (Input.GetKeyUp(KeyCode.K))
        {
            if (player.mana >= 30)
            {
                _shootedAmmo = Instantiate(_trapPrefab, transform.position - Vector3.up * 4.5f, transform.rotation) as GameObject;
                player.PlacedTrap();
            }
            else
            {
                StartCoroutine(noMana.SetActiveText());
            }
        }
        //Summon
        if (Input.GetKeyUp(KeyCode.L))
        {
            if (player.mana >= 50)
            {
                _shootedAmmo = Instantiate(_summonPrefab, transform.position + Vector3.forward * 10, Quaternion.Euler(0f,transform.rotation.y,0f)) as GameObject;
                player.Summon();
            }
            else
            {
                StartCoroutine(noMana.SetActiveText());
            }
        }
    }
}
