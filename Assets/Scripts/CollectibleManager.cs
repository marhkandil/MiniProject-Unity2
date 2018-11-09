using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour {
    public GameObject[] collectibles;
    private Transform playerTransform;
    private List<GameObject> activeCollectibles = new List<GameObject>();
    private float[] distX;
    private bool isDead = false, isPaused = false;
    // Use this for initialization
    void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        distX = new float[3];
        distX[0] = -5f;
        distX[1] = 0f;
        distX[2] = 5f;


    }
    public void onPause()
    {
        isPaused = true;
    }
    public void resume()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update () {
        if (isDead || isPaused)
            return;
        int randomProb = (int)Random.Range(0, 100);
        if (randomProb > 95)
        {
            SpawnCollectible();
        }
    }
    public void onDead()
    {
        isDead = true;
    }
    void SpawnCollectible()
    {
        int randomPrefab = (int)Random.Range(0,3);
        GameObject newPrefab =  Instantiate(collectibles[randomPrefab]) as GameObject;
        print("generatedNewPrefab");
        newPrefab.transform.SetParent(transform);
        int laneRandom = (int)Random.Range(0, 3);
        float zPos = playerTransform.position.z;
        Vector3 newPos = new Vector3(distX[laneRandom], 1.54f, zPos + Random.Range(-10, -30));
        newPrefab.transform.position = newPos;
    }
}
