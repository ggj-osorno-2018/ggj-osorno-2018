﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public void Empezar(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void Salir()
    {
        Application.Quit();
    }
}
 