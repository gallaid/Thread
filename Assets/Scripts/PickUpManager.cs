using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour {
    public GameObject first;
    public GameObject second;
    private Light spotLight;
    private scene currentScene;
    //public GameObject third;

       public enum scene
    {
        Body,
        CarNoHood,
        CarHood,
    }

	// Use this for initialization
	void Start () {
        spotLight = GetComponentInChildren<Light>();
        currentScene = scene.Body;
        MiddleManager(0);

	}
   public void MiddleManager(int changeScene)
    {
        currentScene = currentScene + changeScene;

        switch (currentScene)
        {
            case scene.Body:
                    first.SetActive(true);
                    second.SetActive(false);
                    //third.SetActive(false);
                    spotLight.color = Color.white;
                break;
            case scene.CarNoHood:
                    spotLight.color = Color.red;
                    first.SetActive(false);
                second.SetActive(true);
                break;
            case scene.CarHood:
                    spotLight.color = Color.white;
                    first.SetActive(false);
                    second.SetActive(true);
                break;
        }
    }

}
