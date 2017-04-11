using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {
    GameManager gm;
    public GameObject toSpawn;
    int spawnAmount;
    //when mapped 3 friends, spawn 3 objects.
    //every x seconds later, spawn more objects.
    // Use this for initialization
    public List<GameObject> balls;
	void Start () {
        gm = FindObjectOfType<GameManager>();
        balls = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void spawnObjects() {
      spawnAmount =  gm.friendPositions.Count;
        Debug.Log("spawning " + spawnAmount);

        for (int i = 0; i < spawnAmount; i++) {
            //Instantiate(toSpawn, gm.friendPositions[i], toSpawn.transform.rotation);
           GameObject newBall = Instantiate(toSpawn, randomizeVector(gm.friendPositions[i]), toSpawn.transform.rotation);
            balls.Add(newBall);
        }
    }
    Vector3 randomizeVector(Vector3 original) {
        float offset = .2f;
        Vector3 newVector = new Vector3();
        float x = Random.Range(original.x - offset, original.x + offset);
        float y = Random.Range((original.y - offset -.5f), (original.y + offset));
        float z = Random.Range(original.z - offset, original.z + offset);

        newVector = new Vector3(x,y,z);
        return newVector;

    }
}
