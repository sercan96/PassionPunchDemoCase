using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject ParticleObject;
    void Start()
    {
        transform.rotation = Player.Instance.BulletPos.rotation;
    }
    
    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate((transform.forward) * Time.deltaTime * _speed,Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            GameObject particle = Instantiate(ParticleObject,other.transform.position,other.transform.rotation);
            Destroy(other.gameObject);
            Destroy(particle,2f);
        }
    }
}
