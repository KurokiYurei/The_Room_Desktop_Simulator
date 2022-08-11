using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private HUD gameHud;

    [SerializeField]
    private FPSController player;

    [SerializeField]
    private GameObject door;

    private bool onRange;
    private bool doorOpen;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (onRange && Input.GetKeyDown(player.m_InteractKeyCode))
        {
            switch (doorOpen)
            {
                case true:
                    door.GetComponent<Animation>().Play("ClosingDoor"); ;
                    doorOpen = false;
                    break;

                case false:
                    door.GetComponent<Animation>().Play("OpeningDoor");
                    doorOpen = true;
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //print("Dintre porta");
            gameHud.ShowDoorText();
            onRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //print("Fora porta");
            gameHud.HideDoorText();
            onRange = false;
        }
    }
}
