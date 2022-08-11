using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowText(GameObject textToShow)
    {
        textToShow.SetActive(true);
    }

    public void HideText(GameObject textToShow)
    {
        textToShow.SetActive(false);
    }
}
