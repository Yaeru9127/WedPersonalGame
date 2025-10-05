using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundMove : SetBackGrounds
{
    private Sprite sprite;                          //‰æ–ÊŠO”»’è—pSprite

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //‰Šú‰»
        sprite = this.gameObject.GetComponent<Image>().sprite;
        //float test = backGroundSpeed;
    }

    private void FixedUpdate()
    {
        
    }
}
