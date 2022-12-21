using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Door : MonoBehaviour
{
    [SerializeField]
    private HUD gameHud;

    [SerializeField]
    private FPSController player;

    [SerializeField]
    private GameObject door;

    [SerializeField]
    private GameObject doorText;

    private bool onRange;
    private bool doorOpen;

    [Header("Inputs")]
    private PlayerInput m_playerInput;
    private InputAction m_interactAction;


    // Start is called before the first frame update
    void Start()
    {
        m_playerInput = GetComponent<PlayerInput>();
        m_interactAction = m_playerInput.actions["Interact"];
    }

    // Update is called once per frame
    void Update()
    {
        bool interactionInput = m_interactAction.IsPressed();
        if (onRange && interactionInput)
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
        print(doorOpen);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //print("Dintre porta");
            gameHud.ShowText(doorText);
            onRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //print("Fora porta");
            gameHud.HideText(doorText);
            onRange = false;
        }
    }
}
