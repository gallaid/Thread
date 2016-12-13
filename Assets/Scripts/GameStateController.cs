using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour {
    public Animator animator;
    int placement;

    GameObject[] paths;
	// Use this for initialization
	void Start () {
        //animator = GetComponent<Animator>();
        paths = GameObject.FindGameObjectsWithTag("Path");
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
        TurnOnPath();
        animator.SetInteger("Changeit",placement);
       // print(animator.GetInteger("Changeit"));
    }
    public void TurnOnPath()
    {
        for(int i=0; i < paths.Length; i++)
        {
            if (paths[i].name[0] == placement.ToString()[0])
            {
                print("here");
                MeshRenderer[] turnon;
                turnon = paths[i].GetComponentsInChildren<MeshRenderer>();
                
                foreach(MeshRenderer path in turnon)
                {
                    print(path.name);
                    path.enabled = true;
                }

            }
        }
    }
}
