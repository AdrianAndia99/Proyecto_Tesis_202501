
using System;
using TMPro;
using UnityEngine;

public class GameManager : SingletonPersistent<GameManager>
{
    
    private bool isGameRunning = false;
    private bool isPaused = false;
    [SerializeField] TextMeshProUGUI timeText;
    //[SerializeField] GameData gameData;

    float time = 0;
    void Timer()
    {
        time += Time.deltaTime;

        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

    }
    private void Update()
    {
        
            Timer();
        
    }
    private void Start()
    {
        //databaseHandler = GetComponent<DatabaseHandler>();
        // print("name" + databaseHandler.GetName());
        // databaseHandler.CreateNewPlayer();
        Debug.Log(" ola ");
    }
    private void OnEnable()
    {
       
    }
    private void OnDisable()
    {
       
    }
    public void StartGame()
    {
        isGameRunning = true;
        isPaused = false;
        Time.timeScale = 1f; 
        Debug.Log("Game Started");
    }


    public void EndGame()
    {
        isGameRunning = false;
        Time.timeScale = 1f;
        Debug.Log("Game Over");
       // Debug.Log("Game Over. Score: " + playerFeesh.GetScore());
       // databaseHandler.SaveScore(playerFeesh.GetScore());
    }

    public void PauseGame()
    {
        //if (!isGameRunning || isPaused) return;

        isPaused = true;
        Time.timeScale = 0f;
        Debug.Log("Game Paused");
    }

    public void ResumeGame()
    {
       

        isPaused = false;
        Time.timeScale = 1f;
        Debug.Log("Game Resumed");
    }

    public bool IsPaused() => isPaused;



}
