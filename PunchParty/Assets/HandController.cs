using UnityEngine;
using System.Collections;
using Valve.VR.InteractionSystem;

public class HandController : MonoBehaviour {

    private Hand hand;
	// Use this for initialization
	void Start () {
        hand = GetComponent<Hand>();
	}
	
	// Update is called once per frame
	void Update () {


        if (hand.GetStandardInteractionButtonDown()) {
            //do the thing
            //spawn an object at that location, OR just get the location and add it to whatevers holding the locations
        }
	}


}
