using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Computer : MonoBehaviour
{
    [SerializeField]
    private HUD gameHud;

    [SerializeField]
    private GameObject computerText;

    [SerializeField]
    private string sceneName;
    
    [SerializeField]
    private FPSController player;

    private bool onRange = false;

    // Update is called once per frame
    void Update()
    {
        //if (onRange && Input.GetKeyDown(player.m_InteractKeyCode))
        //{
        //    SceneManager.LoadSceneAsync(sceneName);
        //    Cursor.visible = true;
        //    Cursor.lockState = CursorLockMode.None;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameHud.ShowText(computerText);
            onRange = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            gameHud.HideText(computerText);
            onRange = false;
        }
    }
}
