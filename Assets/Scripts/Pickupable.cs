using UnityEngine;
using System.Collections;

public class Pickupable : MonoBehaviour {
    GameObject beingHeldBy;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


   public void WhosHoldingMe(GameObject player)
    {
        beingHeldBy = player;
    }


}
