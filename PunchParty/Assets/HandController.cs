using UnityEngine;
using System.Collections;
using Valve.VR.InteractionSystem;
using UnityEngine.UI;

public class HandController : MonoBehaviour {

    private Hand hand;
    GameManager gm;
	// Use this for initialization
	void Start () {
        gm = FindObjectOfType<GameManager>();
        hand = GetComponent<Hand>();
	}
	
	// Update is called once per frame
	void Update () {


        if (hand.GetStandardInteractionButtonDown()) {
            gm.addPosition(this.gameObject.transform.position);
            //do the thing
            //spawn an object at that location, OR just get the location and add it to whatevers holding the locations
        }
      
       }


}
