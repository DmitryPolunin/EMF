using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour
{
    private int _lifetime = 40;
    private float speed = 15f;
    private float _obstacleRange = 10f;
    private bool isAttack;
    private bool isMove;
    private Vector3 _enemyPos;

    private float _lifes = 2f;
    private float _attackDelay = 2f;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("atack", false);
        isAttack = false;
        isMove = true;
        StartCoroutine(lifetime());
    }
    private void Update()
    {
        if (isMove == true)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            _animator.Play("FireSummonIdle");
        }
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

        if (isAttack == false)
        {
            isMove = true;
            if (Physics.SphereCast(ray, 1f, out hit))
            {
                if (hit.distance < _obstacleRange && hit.transform.tag != "FireSummon")
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
        if (isAttack == true)
        {
            isMove = false;
            transform.LookAt(_enemyPos);
            if (Vector3.Distance(transform.position, _enemyPos) > 7)
                transform.position = Vector3.MoveTowards(transform.position, _enemyPos, speed * Time.deltaTime);
            else StartCoroutine(Attack());
        }
    }

    public IEnumerator lifetime()
    {
        yield return new WaitForSeconds(_lifetime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player2" || other.tag == "Player3" || other.tag == "Player4")
        isAttack = true; 
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player2" || other.tag == "Player3" || other.tag == "Player4")
        {
            _enemyPos = other.transform.position;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player2" || other.tag == "Player3" || other.tag == "Player4")
        isAttack = false;
    }

    public void ReactToHit()
    {
        _lifes -= 1;
        if (_lifes < 1)
        {
            StartCoroutine(Die());
        }
    }

    private IEnumerator Attack()
    {
        if (_animator.GetBool("atack") == false)
        {
            _animator.SetBool("atack", true);
            yield return new WaitForSeconds(_attackDelay);
            _animator.SetBool("atack", false);
        }
        else yield break;
    }

    public IEnumerator Die()
    {
        //TODO make death anim
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
