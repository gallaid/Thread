using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour {
    public Animator animator;
    int placement;
	// Use this for initialization
	void Start () {
        //animator = GetComponent<Animator>();
        
        placement = 0;
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    public void IncreaceAnimation()
    {
       // print("here");
       // print(animator.GetInteger("Changeit"));
        placement += 1;
        animator.SetInteger("Changeit",placement);
       // print(animator.GetInteger("Changeit"));
    }
}
