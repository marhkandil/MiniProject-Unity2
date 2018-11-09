using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRed : MonoBehaviour {
    public GameObject gameObject;
    private Transform playerTransform;
 
	// Use this for initialization
	void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update () {
        Vector3 curPos = gameObject.transform.position;
        Vector3 playerPos = playerTransform.position;
        if(playerPos.z+10< curPos.z)
        {
            Destroy(gameObject);
        }
	}
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

    }
}
