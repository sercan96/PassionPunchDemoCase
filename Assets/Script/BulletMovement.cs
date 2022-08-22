using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    //public Rigidbody rigidbody;
    

    void Start()
    {
        transform.rotation = Player.Instance.BulletPos.rotation;
    }

    void OnEnable()
    {
        // Debug.Log("Aktifleştim");
        // transform.position = Player.Instance.BulletPos.position;
    }

    void OnDisable()
    {
        //Debug.Log("Pasifim");
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector3 sapma = new Vector3(Random.Range(0, 30), 0f, Random.Range(0, 30));
        transform.Translate((transform.forward) * Time.deltaTime * _speed,Space.World);
        //rigidbody.AddForce(Player.Instance.BulletPos.transform.forward * _speed * Time.deltaTime, ForceMode.Acceleration);
    }
}
