using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

    public GameObject toSpawn;
    int spawnAmount = 3;
    //when mapped 3 friends, spawn 3 objects.
    //every x seconds later, spawn more objects.
	// Use this for initialization
	void Start () {
        spawnObjects();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void spawnObjects() {
        for (int i = 0; i < spawnAmount; i++) {
            Instantiate(toSpawn, toSpawn.transform.position, toSpawn.transform.rotation);

        }
    }
}
