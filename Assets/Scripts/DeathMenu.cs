using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour {
    public Image backgroundImg;
    private bool isShown = false;
    private float transition = 0.0f;
    // Use this for initialization
	void Start () {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (!isShown)
            return;
        transition += Time.deltaTime;
        backgroundImg.color = Color.Lerp(new Color(0, 0, 0, 0), new Color(0,0,0,0.5f),transition);
	}
    public void ToggleEndMenu()
    {
        gameObject.SetActive(true);
        isShown = true;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ToMenu()
    {
        bool mute = MainMenu.muteMusic;
        SceneManager.LoadScene("Menu");
        MainMenu.muteMusic = mute;
    }
}
