using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
    double distX;
    Rigidbody rb;
    private bool isDead =false, isPaused = false;
    public GameObject ball;
    private float animationDuration = 2.0f;
    private float transitionPeriod = 2.0f;
    private float startTime;
    // Use this for initialization
    void Start () {
        rb = gameObject.transform.GetComponent<Rigidbody>();
        startTime = Time.time;
    }
    public void onPause()
    {
        isPaused = true;
    }
    public void resume()
    {
        isPaused = false;
    }

    public void onDead()
    {
        isDead = true;
    }
 
// Update is called once per frame
void Update () {
        if (isDead || isPaused)
            return;
        Vector3 curPosition = transform.position;
        curPosition.y = 1.53f;
        transform.position = curPosition;
        
        if (Time.time -startTime >= animationDuration)
        {
            float posX = curPosition.x;
            transform.Translate((transform.position.x + Input.acceleration.x > 7.0 
                || transform.position.x + Input.acceleration.x < -7.0 ? 0 : Input.acceleration.x), 0, 0);
            
            if (Input.GetKey(KeyCode.LeftArrow)&&posX<7.0)
            {

                gameObject.transform.Translate(0.08f, 0, 0);
                //print("left");
            }
            else if (Input.GetKey(KeyCode.RightArrow)&& posX > -7.0)
            {
                gameObject.transform.Translate(-0.08f, 0, 0);
                //print("right");
            }

        }
    }
}
