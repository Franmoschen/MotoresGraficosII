﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void Init()
    {
        SceneManager.LoadScene("JuegoFinal");
    }
    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }

   public void Quit()
    {
        Application.Quit();
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
}
