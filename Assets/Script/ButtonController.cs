using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public static string BulletName;

    void Start()
    {
  
        BulletName = "Bullet1";
    }

    public void Bullet1Button()
    {
        Debug.Log("Button1 active");
        BulletName = "Bullet1";
    }
    
    public void Bullet2Button()
    {
        Debug.Log("Button2 active");
        BulletName = "Bullet2";
    }
    
    public void Bullet3Button()
    {
        Debug.Log("Button3 active");
        BulletName = "Bullet3";
    }
}
