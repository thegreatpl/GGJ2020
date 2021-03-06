﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public LoadingBar LoadingBar;


    public GameObject GameOverScreen;

    public GameObject GameUI; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ShowLoadingBar()
    {
        LoadingBar.gameObject.SetActive(true);
    }
    public void HideLoadingBar()
    {
        LoadingBar.gameObject.SetActive(false); 
    }
    public void SetLoadingBarProgress(float percentage)
    {
        LoadingBar.SetProgress(percentage); 
    }



    public void SetScreenGameOver(bool active = true)
    {
        GameOverScreen.SetActive(active); 
    }

    public void ShowGameUI()
    {
        GameUI.SetActive(true); 
    }
    public void HideGameUI()
    {
        GameUI.SetActive(false);
    }
}
