using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMotor : MonoBehaviour {
    private Transform lookAt;
    private Vector3 startOffSet, moveVector;
    private float transition = 0.0f;
    private float animationDuration = 2.0f;
    private Vector3 animationOffset = new Vector3(0,5,5);
    private bool topView, changed;
    public Camera main;
    public Camera second;
    public Toggle toggle;
	// Use this for initialization
	void Start () {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffSet = transform.position - lookAt.position;
        topView = false;
        toggle.interactable = false;
    }
    public void toggleCamera(bool topViewBool)
    {
        topView = topViewBool;
       // print(toggle.isOn);
        if(topViewBool)
        {
            transform.Rotate(new Vector3(90, 0, 0));
            
        }
        else
        {
            transform.Rotate(new Vector3(-90, 0, 0));
        }

    }
    // Update is called once per frame
    void Update () {
        moveVector = lookAt.position + startOffSet;
        moveVector.x = 0;
        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5);
        if (Input.GetKeyUp(KeyCode.C))
        {
            topView = !topView;
            toggle.isOn = topView;
        }
        
            if (transition > 1.0f)
            {
            toggle.interactable = true;
            if (!topView)
                {
                transform.position = moveVector+ new Vector3(0,0, 2f);
                }
                else
                {
                print("here");
                transform.position = moveVector + new Vector3(0,7,-10);
                }
            }
            else
            {
                //Animation at the start of the gaaaaame
                transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition) + new Vector3(0, 0, 2f); ;
                transition += Time.deltaTime * 1 / animationDuration;
                transform.LookAt(lookAt.position + Vector3.up);
            }
        

	}
}
