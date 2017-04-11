using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour {
    int count = 0;
    GameManager gm;
    // Use this for initialization
    void Start () {
        gm = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision");

        if (other.tag == "ball")
        {
            count++;
            gm.decrimentBallCount(other.gameObject);
            Destroy(other.gameObject);
            gm.increaseScore();
            Debug.Log("count: " + count);
        }
    }
}
