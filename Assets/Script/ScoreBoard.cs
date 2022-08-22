using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public Text BulletTxt;
    private int _bulletScore;
    
    public void IncreaseBulletNumber()
    {
        _bulletScore++;
        BulletTxt.text = _bulletScore.ToString();
    }
}
