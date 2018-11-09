using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneManager : MonoBehaviour {
    public GameObject[] zones;
    private Transform playerTransform;
    private float waitTime = 0.0f;

    // Use this for initialization
    private bool isDead = false, isPaused = false;
    void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }
    public void onPause()
    {
        isPaused = true;
    }
    public void resume()
    {
        isPaused = false;
    }

    void Update()
    {
        if (isDead || isPaused)
            return;
        int randomProb = (int)Random.Range(0, 100);
        float timeCur = Time.time;
        if (waitTime + 9 < timeCur)
        {
            waitTime = timeCur;
            SpawnCollectible();
            
        }
    }
    public void onDead()
    {
        isDead = true;
        Debug.Log("killed off zone manager");
    }
    void SpawnCollectible()
    {
        int randomPrefab = (int)Random.Range(0, 3);
        GameObject newPrefab = Instantiate(zones[randomPrefab]) as GameObject;
        newPrefab.transform.SetParent(transform);
        float zPos = playerTransform.position.z;
        Vector3 newPos = new Vector3(0, 1.54f, zPos -30);
        newPrefab.transform.position = newPos;
    }
}
