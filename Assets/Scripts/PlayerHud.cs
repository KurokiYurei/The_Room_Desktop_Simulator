using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{
    FPSController player;
    float m_Health, m_Shield, m_Timer;
    int m_TotalAmmo, m_ClipAmmo;

    [Header("Player")]
    public Text m_HealthText;
    public Text m_ShieldText;
    public Text m_AmmoText;

    [Header("Shooting Gallery")]
    public GameObject m_ShootingGalleryTip;
    public GameObject m_ShootingGalleryHud;
    public GameObject m_ShootingGalleryResults;
    public Text m_ShootingGalleryTipText, m_ShootingGalleryScoreText,
        m_ShootingGalleryTimerText, m_ShootingGalleryResultsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }    

    ///////SHOOTING GALLERY
    //public void ShowTip()
    //{
    //    m_ShootingGalleryTip.SetActive(true);
    //}
    //public void HideTip()
    //{
    //    m_ShootingGalleryTip.SetActive(false);
    //}
    //public void ChangeTip(string text)
    //{
    //    m_ShootingGalleryTipText.text = text;
    //}

    //public void ShowHud()
    //{
    //    m_ShootingGalleryHud.SetActive(true);
    //}
    //public void HideHud()
    //{
    //    m_ShootingGalleryHud.SetActive(false);
    //}

    //public void ShowResults(string text)
    //{
    //    m_ShootingGalleryResultsText.text = text;
    //    m_ShootingGalleryResults.SetActive(true);
    //    m_Timer = 3f; 
    //}
    //public void HideResults()
    //{
    //    m_ShootingGalleryResults.SetActive(false);
    //}

    //void TimerHud()
    //{
    //    m_ShootingGalleryTimerText.text = ShootingGallery.instance.m_Timer.ToString("00");
    //}
    //void ScoreHud()
    //{
    //    m_ShootingGalleryScoreText.text = ShootingGallery.instance.m_Score.ToString("00") + '/' + ShootingGallery.instance.m_ScoreGoal.ToString("00");
    //}
}
