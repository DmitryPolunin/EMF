using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Player _player = null;
    [SerializeField] private NoManaText _noMana = null;

    [SerializeField] private GameObject _fireballPrefab = null;
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
            if (_player.mana >= 15)
            {
                _shootedAmmo = Instantiate(_fireballPrefab, _shootDir.position, _shootDir.rotation) as GameObject;
                _player.ShootedFireball();
            }
            else
            {
                StartCoroutine(_noMana.SetActiveText());
            }
        }
        //Place trap
        if (Input.GetKeyUp(KeyCode.K))
        {
            if (_player.mana >= 30)
            {
                _shootedAmmo = Instantiate(_trapPrefab, transform.position - Vector3.up * 4.5f, transform.rotation) as GameObject;
                _player.PlacedTrap();
            }
            else
            {
                StartCoroutine(_noMana.SetActiveText());
            }
        }
        //Summon
        if (Input.GetKeyUp(KeyCode.L))
        {
            if (_player.mana >= 50)
            {
                _shootedAmmo = Instantiate(_summonPrefab, transform.position + Vector3.forward * 10, Quaternion.Euler(0f,transform.rotation.y,0f)) as GameObject;
                _player.Summon();
            }
            else
            {
                StartCoroutine(_noMana.SetActiveText());
            }
        }
    }
}
