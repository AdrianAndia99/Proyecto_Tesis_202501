
using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using System;
//using Unity.VisualScripting;
public class UIManager : SingletonPersistent<UIManager>
{

    /*
     
    [SerializeField] TextMeshProUGUI _objQuantity;

     private float fadeInDuration = 0.5f;
     private float fadeOutDuration = 0.5f;
    private int fadeInAmount = 0;
    private int fadeOutAmount = 1;
    [SerializeField] CanvasGroup curtains;
    [SerializeField] CanvasGroup General;
    [SerializeField] Transform initCurtains;
    [SerializeField] Transform endCurtains;
    [SerializeField] Transform centerCurtains;
    [SerializeField] Transform leftStay;
    [SerializeField] TextMeshProUGUI zoneType;
    //Tween fade;
    [SerializeField] GameObject cineToPlay;
    
     [SerializeField] Sequence fade;
    [SerializeField] Sequence fadeOut;
    [SerializeField] Sequence curtain;
    [SerializeField] Ease curtainsase;
    [SerializeField] Ease textEase;

    [SerializeField] CanvasGroup pausePanel;



    [SerializeField] CanvasGroup pausefade;
    [SerializeField] GameObject localLeft;
    private float fadeOutpause = 0.8f;
    [SerializeField] Transform TypeZoneAnchor;

    [SerializeField] TextMeshProUGUI zoneNamePause;
    [SerializeField] Image bannerPause;
    [SerializeField] Image FadePause;
    [SerializeField] Button PauseButton;
    [SerializeField] CanvasGroup EndPanel;

    [SerializeField] GameObject PauseMain;
   

    [SerializeField] GameObject PauseInGame;
    [SerializeField] GameObject AudioSetMenu;*/


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "obj")
        {
            //_objQuantityIndex++;
        }
    }
    private void Awake()
    {
        
    }
    private void Start()
    {
        //FadeIn();
    }
    void PlayActive()
    { 
            
       
    }
    public void PauseFadePanel()
    {
        //pausePanel.SetActive(true);
       

    }
    
    
}
