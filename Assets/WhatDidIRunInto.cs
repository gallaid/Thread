using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatDidIRunInto : MonoBehaviour {
    Grab FPCharacter;
	// Use this for initialization
	void Start () {
        FPCharacter = GetComponentInChildren<Grab>();
	}
	

    void OnTriggerEnter(Collider col)
    {
        if(col.name=="Car"&& FPCharacter.carried.tag == "Hood")
        {
            FPCharacter.ITriggeredCar(col.gameObject,true);
        }
    }
    void OnTriggerExit()
    {
        FPCharacter.ITriggeredCar(gameObject, false);
    }
}
