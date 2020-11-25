using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private float _speed = 50f;
    public float damage = 30f;
    [SerializeField] private GameObject _explosion;
    private GameObject _explosioned;

    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);  
    }
    private void OnCollisionEnter(Collision collision)
    {
        ReactiveTarget target = collision.gameObject.GetComponent<ReactiveTarget>();
        Summon summon = collision.gameObject.GetComponent<Summon>();
        if(collision.gameObject.tag == "Player2" && target != null)
        {
            target.ReactToHit(damage);
        }
        if(collision.gameObject.tag == "FireSummon" && summon != null)
        {
            summon.ReactToHit();
        }
        Explode();
        Destroy(this.gameObject);
    }

    private void Explode()
    {
        _explosioned = Instantiate(_explosion, gameObject.transform.position, Quaternion.Euler(-90,-90,0)) as GameObject;
        Destroy(_explosioned,0.6f);
    }
}
