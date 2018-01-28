﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class barranivel1 : MonoBehaviour {

    public Image vida;
    float hp, maxHp = 100f;
    public PlayerControlador respawn;
    




    // Use this for initialization
    void Start()
    {
        hp = maxHp;

    }


    public void TakeDamage(float amount)
    {
        hp = Mathf.Clamp(hp - amount, 0f, maxHp);
        vida.transform.localScale = new Vector2(hp / maxHp, 1);



    }

    void Update()
    {



        if (vida.transform.localScale.x == 0)

        {





            SceneManager.LoadScene(0);







        }
    }
}
