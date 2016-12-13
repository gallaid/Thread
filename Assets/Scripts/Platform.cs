using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {
    Light Light;
    GameStateController StateController;

	// Use this for initialization
	void Start () {
        Light = gameObject.GetComponentInChildren<Light>();
        StateController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameStateController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Object1")
        {
            Light.color = Color.red;
            StateController.IncreaceAnimation();
            print("it is touching me");
        }
    }
}
