using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroundManager : MonoBehaviour {
    public GameObject[] planes;
    private Transform playerTransform;
    private float spawnZ = -10.0f; //where do we wanna put it
    private float planeLength = -35;
    private int amountOfPlanes = 4;
    private List<GameObject> activePlanes = new List<GameObject>();
    private float safeZone = 50;
    private bool isDead = false;
    private bool isPaused = false;
    // Use this for initialization
	void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for(int i = 0; i < amountOfPlanes; i++)
        {
            SpawnPlane();
        }
    }

    // Update is called once per frame
    void Update() {
        if (isDead || isPaused)
            return;
        if (playerTransform.position.z+safeZone < (spawnZ - (amountOfPlanes * planeLength)))
        {
          SpawnPlane();
            DeletePlane();
        }
	}
    public void onDead()
    {
        isDead = true;
    }
    public void onPause()
    {
        isPaused = true;
    }
    public void resume()
    {
        isPaused = false;
    }
    private void SpawnPlane(int prefabIndex = -1)
    {
        GameObject go1, go2, go3;
        go1 = Instantiate(planes[0]) as GameObject;
        go2 = Instantiate(planes[1]) as GameObject;
        go3 = Instantiate(planes[2]) as GameObject;
        go1.transform.SetParent(transform);
        go2.transform.SetParent(transform);
        go3.transform.SetParent(transform);
        Vector3 newPos = Vector3.forward * spawnZ;
        go1.transform.position = new Vector3(-6.5f, 0.9f, newPos.z);
        go2.transform.position = new Vector3(0, 1.03f, newPos.z);
        go3.transform.position = new Vector3(6.5f, 0.9f, newPos.z);
        activePlanes.Add(go1);
        activePlanes.Add(go2);
        activePlanes.Add(go3);
        spawnZ += planeLength;
    }
    private void DeletePlane()
    {
        Destroy(activePlanes[0]);
        Destroy(activePlanes[1]);
        Destroy(activePlanes[2]);
        activePlanes.RemoveAt(0);
        activePlanes.RemoveAt(0);
        activePlanes.RemoveAt(0);


    }
}
