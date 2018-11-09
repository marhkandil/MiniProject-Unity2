using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void backtoMainMenu()
    {

        SceneManager.LoadScene("Menu");
    }
    public void backtoMainMenu2()
    {

        SceneManager.LoadScene("mini");
    }
}
