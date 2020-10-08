using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int health = 100;
    private int maxHealth = 100;
    private int healthRecSpeed = 0;
    private int _mana = 0;
    public int mana 
    {
        get { return _mana; }
    }
    private int maxMana = 100;
    private int manaRecSpeed = 3;
    
    private HealthBar healthBar;
    private ManaBar manaBar;

    
    void Start()
    {
        healthBar = GetComponentInChildren<HealthBar>();
        manaBar = GetComponentInChildren<ManaBar>();

        if (manaRecSpeed != 0) StartCoroutine(ManaRecovery());
        if (healthRecSpeed != 0) StartCoroutine(HealthRecovery());
    }
    public IEnumerator ManaRecovery()
    {
            while (_mana < maxMana)
            {
                _mana += manaRecSpeed;
                ChangeMana();
                yield return new WaitForSeconds(0.5f);
            }
    }
    public IEnumerator HealthRecovery()
    {
            while (health < maxHealth)
            {
                health += healthRecSpeed;
                ChangeHealth();
                yield return new WaitForSeconds(0.5f);
            }
    }

    public void ChangeHealth()
    {
        healthBar.SetHealth(health);
    }

    public void ChangeMana()
    {
        manaBar.SetMana(mana);
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
        manaRecSpeed += 3;
        yield return new WaitForSeconds(60);
        manaRecSpeed -= 3;
    }
}
