﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
    private bool isShown = false;
    private float transition = 0.0f;
    public Image backgroundImg;
    // Use this for initialization
    void Start() {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (!isShown)
            return;
        transition += Time.deltaTime;
        backgroundImg.color = Color.Lerp(new Color(0, 0, 0, 0), new Color(0, 0, 0, 0.5f), transition);
    }
    public void Pause()
    {

        isShown = true;
        gameObject.SetActive(true);
    }
    public void Resume()
    {
        isShown = false;
        transition = 0.0f;
        gameObject.SetActive(false);

    }
    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }
}
