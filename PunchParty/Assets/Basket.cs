using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour {
    int count = 0;
	// Use this for initialization
	void Start () {
	
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
            Destroy(other.gameObject);
            Debug.Log("count: " + count);
        }
    }
}
