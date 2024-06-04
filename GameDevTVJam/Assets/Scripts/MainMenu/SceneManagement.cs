using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    public static SceneManagement Instance;

    public event EventHandler OnSceneChange;

    [SerializeField] PlayerStats playerStats;

    [SerializeField] string sceneName;
    private string gameOver;
    [SerializeField] float timer = 0;
    float delayBeforeLoad = 3f;
    bool startTimer = false;

    private void Awake()
    {
        if (Instance == null){
            Instance = this;
        }
        gameOver = "GameOver";
    }

    private void Start()
    {
        playerStats.OnDieEvent += PlayerStats_OnDieEvent;
    }

    private void PlayerStats_OnDieEvent(object sender, EventArgs e)
    {
        DieEventStart();
    }

    private void Update()
    {
        if (startTimer == true && timer <3)
        {
            timer += Time.deltaTime;
            if (timer > delayBeforeLoad)
            {
                Debug.Log("NextScene");
                GoNextScene();
            }
        }
        
    }

    public void GoNextSceneWithTimer()
    {
        startTimer = true;
        OnSceneChange?.Invoke(this, EventArgs.Empty);
        

    }


    public void DieEventStart()
    {
        GoNextSceneWithTimer();
    }
    public void GoNextScene()
    {
        Debug.Log("NextScene");
        SceneManager.LoadScene(sceneName);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(gameOver);
    }
}
