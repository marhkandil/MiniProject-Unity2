using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public AudioSource audio;
    public Scene miniScene;
    public static bool muteMusic = false;
    public Toggle musicToggle;
	// Use this for initialization
	void Start () {
        if (muteMusic)
        {
            musicToggle.isOn = true;
        }
        else
        {
            musicToggle.isOn = false;
        }
	}
	public void mute(bool mute)
    {
        muteMusic = mute;
        if (mute)
        {
            print("muted");
            audio.Pause();
        }
        else
        {
            audio.UnPause();
        }
    }
	// Update is called once per frame
	void Update () {
        if (muteMusic)
        {
            audio.mute = true;
        }
        else
        {
            audio.mute = false;
        }

    }
    public void ToGame()
    {
        SceneManager.LoadScene("mini");
    }
    public void ToHowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    public void ToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
