using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour {
    public GameObject gameObject;
    private Transform playerTransform;

    // Use this for initialization
    void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
            print("hello");
        

    }
    
}
