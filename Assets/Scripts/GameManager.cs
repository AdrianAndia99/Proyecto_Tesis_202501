
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonPersistent<GameManager>
{

    private bool isGameRunning = false;
    private bool isPaused = false;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] private ProgressDataSO progressDataSO;
    //[SerializeField] GameData gameData;

    float time = 0;
    [SerializeField] Toggle action;
    void Timer()
    {
        time += Time.deltaTime;

        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

    }
    private void Update()
    {
        // to check .. action.isOn= true;
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
        if (progressDataSO != null)
        {
            progressDataSO.time = time; // Guarda el tiempo actual en el SO
        }
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
    public float GetTime() => time;



}
