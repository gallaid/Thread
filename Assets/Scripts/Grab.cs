using UnityEngine;
using System.Collections;

public class Grab : MonoBehaviour {
    Camera mainCam;
    bool Carrying;
    GameObject carried;
    public int infront;
	// Use this for initialization
	void Start () {
        mainCam = Camera.main;
	}

    // Update is called once per frame
    void Update()
    {
        if (Carrying)
        {

            carry(carried);
        }else
        {
            pickup();
        }
    }



    void carry(GameObject o)
    {
        o.GetComponent<Rigidbody>().isKinematic = true;
        o.transform.position = mainCam.transform.position + mainCam.transform.forward * infront;
        if (Input.GetKeyDown(KeyCode.R))
        {
            drop(o);
        }
    }
    void pickup()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCam.ScreenPointToRay(new Vector2(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Pickupable p = hit.collider.GetComponent<Pickupable>();
                if (p != null)
                {
                    Carrying = true;
                    carried = p.gameObject;
                }
            }
        }

    }
    void drop(GameObject o)
    {
        o.GetComponent<Rigidbody>().isKinematic = false;
        carried = null;
        Carrying = false;
    }
}
