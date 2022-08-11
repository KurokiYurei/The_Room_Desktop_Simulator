using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField]
    private GameObject interactDoorText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDoorText()
    {
        interactDoorText.SetActive(true);
    }

    public void HideDoorText()
    {
        interactDoorText.SetActive(false);
    }
}
