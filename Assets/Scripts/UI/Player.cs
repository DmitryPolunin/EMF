using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _health = 100;
    private int _maxHealth = 100;
    private int _healthRecSpeed = 0;
    private int _mana = 0;
    private int _maxMana = 100;
    private int _manaRecSpeed = 3;
    public int mana 
    {
        get { return _mana; }
    }
    
    private HealthBar _healthBar;
    private ManaBar _manaBar;

    
    void Start()
    {
        _healthBar = GetComponentInChildren<HealthBar>();
        _manaBar = GetComponentInChildren<ManaBar>();

        if (_manaRecSpeed != 0) StartCoroutine(ManaRecovery());
        if (_healthRecSpeed != 0) StartCoroutine(HealthRecovery());
    }
    public IEnumerator ManaRecovery()
    {
            while (_mana < _maxMana)
            {
                _mana += _manaRecSpeed;
                ChangeMana();
                yield return new WaitForSeconds(0.5f);
            }
    }
    public IEnumerator HealthRecovery()
    {
            while (_health < _maxHealth)
            {
                _health += _healthRecSpeed;
                ChangeHealth();
                yield return new WaitForSeconds(0.5f);
            }
    }

    public void ChangeHealth()
    {
        _healthBar.SetHealth(_health);
    }

    public void ChangeMana()
    {
        _manaBar.SetMana(mana);
    }

    public void ShootedFireball()
    {
        _mana -= 15;
    }

    public void PlacedTrap()
    {
        _mana -= 30;
    }

    public void Summon()
    {
        _mana -= 50;
    }

    public IEnumerator BlueBuff()
    {
        _manaRecSpeed += 3;
        yield return new WaitForSeconds(60);
        _manaRecSpeed -= 3;
    }
}
