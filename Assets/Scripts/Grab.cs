using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Grab : MonoBehaviour
{
    Camera mainCam;
    bool Carrying;
    public GameObject carried;
    public float infront;
    public float ViewBlock;
    public FirstPersonController controller;
    public float walkSpeed;
    private float runSpeed;
    public PickUpManager changer;

    private PlaySounds pickUpSound;
    public bool canPlace;

    GameObject Car;

    // Use this for initialization
    void Start()
    {
        mainCam = Camera.main;
        controller = GetComponentInParent<FirstPersonController>();
        runSpeed = walkSpeed * 2;
        pickUpSound = GetComponent<PlaySounds>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Carrying)
        {

            carry(carried);
        }
        else
        {
            pickUp();
        }
    }
    void carry(GameObject o)
    {
        controller.m_WalkSpeed = walkSpeed;
        controller.m_RunSpeed = runSpeed;
        o.GetComponent<Rigidbody>().isKinematic = true;
        o.transform.position = mainCam.transform.position + mainCam.transform.forward * infront + mainCam.transform.up * ViewBlock;
        o.transform.rotation = mainCam.transform.rotation;
        if (Input.GetKeyDown(KeyCode.E))
        {
            drop(o.gameObject);
        }
    }
    void pickUp()
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

                    pickUpSound.playManager(p.gameObject.tag);
                    changer.MiddleManager(+1);
                    Carrying = true;
                    carried = p.gameObject;
                    p.WhosHoldingMe(this.gameObject);
                }
            }
        }
    }

    void drop(GameObject o)
    {
        if (!canPlace)
        {
            o.GetComponent<Rigidbody>().isKinematic = false;
            carried = null;
            Carrying = false;
            controller.m_WalkSpeed = 5;
            controller.m_RunSpeed = 10;
            changer.MiddleManager(-1);
            pickUpSound.playManager("Pause");
            o.GetComponent<Pickupable>().WhosHoldingMe(null);
        }
        else
        {

            Carrying = false;
            controller.m_WalkSpeed = 5;
            controller.m_RunSpeed = 10;
            Car.GetComponent<PlaceHood>().Hood.SetActive(true);
            Destroy(carried);
            pickUpSound.playManager("CloseHood");
            o.GetComponent<Pickupable>().WhosHoldingMe(null);
            StartCoroutine(DelaySwitch());


        }
    }


    IEnumerator DelaySwitch()
    {
        yield return new WaitForSeconds(1);
        changer.MiddleManager(+1);
    }
    public void ITriggeredCar(GameObject col, bool Stillin)
    {
        if (Stillin)
        {
            Car = col;
            canPlace = true;
        }

    }

}
