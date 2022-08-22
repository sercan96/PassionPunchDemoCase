using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    
    [SerializeField] private float _bulletWaitTime;
    public Animator Animator;
    public GameObject BulletPrefab;
    public Transform BulletPos;
    public ScoreBoard ScoreBoard;


    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChooseBullet();
        }
    }
    public void OpenAndCloseAnimator(bool currentState)
    {
        Animator.SetBool("isWalk",currentState);
    }

    void ChooseBullet()
    {
        if (!PlayerMovement.IsPlayerMove) return;
        switch (ButtonController.BulletName)
        {
            case "Bullet1":
                StartCoroutine(CreateBullet("Bullet1",_bulletWaitTime));
                break;
            case "Bullet2":
                StartCoroutine(CreateBullet("Bullet2",_bulletWaitTime));
                break;
            case "Bullet3":
                StartCoroutine(CreateBullet("Bullet3",_bulletWaitTime));
                break;
            default:
                StartCoroutine(CreateBullet("Bullet1",_bulletWaitTime));
                break;
        }
    
    }

    IEnumerator CreateBullet(string chooseBullet, float time)
    {
        int createRandomNumber = Random.Range(1, 4);
        for (int i = 0; i < createRandomNumber; i++)
        {
            GameObject obj =ObjectPooler.instance.SpawnFromPool(chooseBullet, BulletPos.transform.position, Quaternion.identity);
            ScoreBoard.IncreaseBulletNumber();
            yield return new WaitForSeconds(time);
            obj.SetActive(false);
        }
      
    }
}       

